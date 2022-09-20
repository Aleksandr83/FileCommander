// Copyright (c) 2021 Lukin Aleksandr
using alg.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types
{
    public class PasswordContainer : IPasswordContainer
    {
        private const int ALG_PASS_NOT_CODED   = 0;
        public virtual int      Algoritm { get; set; }
        public virtual String   Password { get; set; }
        public virtual String   Salt     { get; set; }

        public PasswordContainer()
        {
            Algoritm = GetDefaultAlg();
        }

        protected virtual int GetDefaultAlg()
        {
            return ALG_PASS_NOT_CODED;
        }

        protected virtual bool IsNotCoded() => Algoritm == ALG_PASS_NOT_CODED;

        protected virtual String Encoded(String value,int alg)
        {
            throw new NotImplementedException();
        }

        protected virtual String Decoded(String value, int alg)
        {
            throw new NotImplementedException();
        }

        public String GetPassword()
        {
            return GetPassword(Algoritm);
        }

        protected virtual String GetPassword(int alg)
        {
            return IsNotCoded() ? Password : Decoded(Password, alg);
        }

        public virtual void SetPassword(String password)
        {
            SetPassword(password, Algoritm);
        }

        protected void SetPassword(String password, int alg)
        {
            Password = IsNotCoded() ? password : Encoded(password, alg);
        }

        public virtual String ToJson()
        {
            return JsonHelper.Serialize(this);
        }
    }
}
