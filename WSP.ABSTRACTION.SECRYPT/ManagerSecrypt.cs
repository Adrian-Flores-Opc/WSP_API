using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSP.ABSTRACTION.SECRYPT
{
    public class ManagerSecrypt : IManagerSecrypt
    {
        private readonly string semilla;
        public ManagerSecrypt(string semilla)
        {
            this.semilla = semilla;
        }
        public string Encriptar(string value)
        {
            try
            {
                var SegCrypt = new SegCryptV2(semilla);
                var result = SegCrypt.FunctionEncryptDecrypt(true, value);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Desencriptar(string value)
        {
            try
            {
                var SegCrypt = new SegCryptV2(semilla);
                var result = SegCrypt.FunctionEncryptDecrypt(false, value);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Tuple<bool, string> Check()
        {
            try
            {
                var secryp = new SegCryptV2(semilla);
                return Tuple.Create(true, $"LA SEMILLA {semilla} FUE ENCONTRADA.");
            }
            catch (Exception ex)
            {
                return Tuple.Create(false, ex.Message);
            }
        }
    }
}

