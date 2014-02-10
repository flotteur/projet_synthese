using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;


namespace WPF_ClientSynthèse
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IDisposable
    {
      

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            //if (disposing)
            //    if (Proxy != null) {
            //        Proxy. .Dispose();
            //        Proxy = null;
            //    }
        }

        ~App() {
            Dispose(false);
        }
    }
}
