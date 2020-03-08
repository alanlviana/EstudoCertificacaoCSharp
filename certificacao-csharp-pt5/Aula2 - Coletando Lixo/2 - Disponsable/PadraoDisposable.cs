using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace certificacao_csharp_pt5.aula2
{
    class PadraoDisposable : IExecutavel
    {
        public void Executar()
        {
            var mensageiro = new MensageiroNotepad();

            mensageiro.EnviarMensagem("Hello World!");

            mensageiro.Dispose();
        }
    }

    class MensageiroNotepad: IDisposable
    {
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        private IntPtr ponteiroNotepad = new IntPtr(0);
        private StreamWriter escritor = new StreamWriter("mensagens.txt");


        public void EnviarMensagem(string mensagem)
        {
            escritor.WriteLine(mensagem);
            escritor.Flush();

            Process[] notepads = Process.GetProcessesByName("notepad");
            if (notepads.Length == 0) return;

            if (notepads[0] != null)
            {
                ponteiroNotepad = FindWindowEx(notepads[0].MainWindowHandle, IntPtr.Zero, "Edit", null);

                SendMessage(ponteiroNotepad, 0x000C, 0, mensagem);
            } 
        }


        const uint PROCESS_DUP_HANDLE = 0x0040;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess,
            [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, IntPtr dwProcessId);

        [Flags]
        enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DuplicateHandle(IntPtr hSourceProcessHandle,
           IntPtr hSourceHandle, IntPtr hTargetProcessHandle, out IntPtr lpTargetHandle,
           uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, DuplicateOptions dwOptions);

        [Flags]
        enum DuplicateOptions : uint
        {
            DUPLICATE_CLOSE_SOURCE = (0x00000001),
            DUPLICATE_SAME_ACCESS = (0x00000002),
        }

        public static bool CloseHandleEx(IntPtr pid, IntPtr handle)
        {
            IntPtr hProcess = OpenProcess(ProcessAccessFlags.DupHandle, false, pid);
            IntPtr dupHandle = IntPtr.Zero;
            bool success = DuplicateHandle(hProcess, handle, IntPtr.Zero, out dupHandle, 0, false, DuplicateOptions.DUPLICATE_CLOSE_SOURCE);
            CloseHandle(hProcess);
            return success;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    escritor.Dispose();
                }
                
                // Recursos não gerenciados
                CloseHandleEx(Process.GetCurrentProcess().MainWindowHandle, ponteiroNotepad);
                ponteiroNotepad = new IntPtr(0);

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~MensageiroNotepad()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }

}
