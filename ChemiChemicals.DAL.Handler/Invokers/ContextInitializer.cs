using ChemiChemicals.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChemiChemicals.Repositry.Invokers
{
    public class ContextInitializer:IDisposable
    {
        protected ChemiContext _chemiContext { 
            get {
                return new ChemiContext();
            }
        }

        public void Dispose()
        {
            //force dispose 
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //to close the connection 
                _chemiContext.Dispose();
            }
        }
        ~ContextInitializer()
        {
            Dispose(false);
        }
    }
}
