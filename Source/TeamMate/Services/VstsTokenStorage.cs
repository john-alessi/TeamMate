using Microsoft.VisualStudio.Services.Common.TokenStorage;
using System.Collections.Generic;

namespace Microsoft.Tools.TeamMate.Services
{
    class VstsTokenStorage : VssTokenStorage
    {
        public override string GetProperty(VssToken token, string name)
        {
            throw new System.NotImplementedException();
        }

        public override bool RemoveAll()
        {
            throw new System.NotImplementedException();
        }

        public override bool RemoveTokenSecret(VssToken token)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<VssToken> RetrieveAll(string kind)
        {
            throw new System.NotImplementedException();
        }

        public override string RetrieveTokenSecret(VssToken token)
        {
            throw new System.NotImplementedException();
        }

        public override bool SetProperty(VssToken token, string name, string value)
        {
            throw new System.NotImplementedException();
        }

        public override bool SetTokenSecret(VssToken token, string tokenValue)
        {
            throw new System.NotImplementedException();
        }

        protected override VssToken AddToken(VssTokenKey tokenKey, string tokenValue)
        {
            throw new System.NotImplementedException();
        }

        protected override bool RemoveToken(VssTokenKey tokenKey)
        {
            throw new System.NotImplementedException();
        }

        protected override VssToken RetrieveToken(VssTokenKey tokenKey)
        {
            throw new System.NotImplementedException();
        }
    }
}
