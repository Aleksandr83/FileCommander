// Copyright (c) 2021 Lukin Aleksandr
using alg.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types
{
    public class Password : IPassword
    {
        IPasswordContainer _PasswordContainer;        

        public Password()
        {
            var passwordContainer = CreatePasswordContainer();
            SetPasswordContainer(passwordContainer);
        }

        protected virtual IPasswordContainer CreatePasswordContainer()
        {
            return new PasswordContainer();
        }

        protected virtual void SetPasswordContainer(IPasswordContainer container)
        {
            _PasswordContainer = container;
        }
        protected IPasswordContainer GetPasswordContainer() => _PasswordContainer;
        public virtual String GetValue()
        {           
            return GetPasswordContainer()?.GetPassword();
        }
        public virtual void SetValue(String value)
        {
            GetPasswordContainer()?.SetPassword(value);
        }
        public virtual void LoadEncodeString(String encodePassword)
        {            
            if (String.IsNullOrEmpty(encodePassword.Trim()))
            {
                SetValue(String.Empty);
                return;
            }
            var json = Base64Helper.Base64Decode(encodePassword.Trim());
            var passwordContainer = ContainerDeserilize(json);
            SetPasswordContainer(passwordContainer);
        }

        protected virtual String ContainerSerilize() 
            => GetPasswordContainer()?.ToJson();

        protected virtual IPasswordContainer ContainerDeserilize(String json)
        {
            return JsonHelper.Deserialize<PasswordContainer>(json);
        }

        public virtual String GetEncodeString()
        {        
            return Base64Helper.Base64Encode(ContainerSerilize());
        }

    }
}
