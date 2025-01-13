namespace CompanyTest.API.Endpoints;

public static class ApiRoutes
{
    public static class UserRoutes
    {
        public const string Create = "/api/user/create";
        public const string Update = "/api/user/update";
        public const string Delete = "/api/user/delete";
        public const string GetById = "/api/user/get/";
        public const string Get = "/api/user/getall";

    }

    public static class CompanyRoutes
    {
        public const string Create = "/api/company/create";
        public const string Update = "/api/company/update";
        public const string Delete = "/api/company/delete";
        public const string GetById = "/api/company/get";
        public const string Get = "/api/company/getall";
    }
}
