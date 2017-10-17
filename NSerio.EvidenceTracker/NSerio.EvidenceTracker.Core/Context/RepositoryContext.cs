using Relativity.API;
using System;

namespace NSerio.EvidenceTracker.Core.Context
{
    public static class RepositoryContext
    {
        public static IHelper CurrentHelper
        {
            get
            {
                return GetCurrentHelper();
            }
        }
        public static IAuthenticationMgr CurrentAuthentication
        {
            get
            {
                return GetAuthenticationFnc();
            }
        }


        public static int CurrentWorkspace
        {
            get
            {
                return GetCurrentWorkspace();
            }
        }
        public static void SetHelper(Func<IHelper> helper)
        {
            GetCurrentHelper = helper;
        }
        public static void SetAuthenticationFnc(Func<IAuthenticationMgr> authenticationGetter)
        {
            GetAuthenticationFnc = authenticationGetter;

        }
        public static void SetWorkspace(Func<int> workspace)
        {
            GetCurrentWorkspace = workspace;
        }

        private static Func<IHelper> GetCurrentHelper;
        private static Func<IAuthenticationMgr> GetAuthenticationFnc;
        private static Func<int> GetCurrentWorkspace;
    }
}