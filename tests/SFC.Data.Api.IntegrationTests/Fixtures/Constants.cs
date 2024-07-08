﻿using SFC.Data.Infrastructure.Settings;

namespace SFC.Data.Api.IntegrationTests.Fixtures;
public static class Constants
{
    public const string ACCEPT_LANGUAGE = "Accept-Language";

    public const string API_DATA = "/api/data";

    public const string DATA_ACCESS_TOKEN_VALID = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImIwNzg4ZDJmLTgwMDMtNDNjMS05MmE0LWVkYzc2YTdjNWRkZSIsInN1YiI6ImIwNzg4ZDJmLTgwMDMtNDNjMS05MmE0LWVkYzc2YTdjNWRkZSIsImp0aSI6IjQxMTAwODJlIiwic2NvcGUiOlsic2ZjLmRhdGEuZnVsbCIsInByb2ZpbGUiLCJvcGVuaWQiLCJvZmZsaW5lX2FjY2VzcyJdLCJhdWQiOiJzZmMuZGF0YSIsIm5iZiI6MTcxOTkyOTU5MiwiZXhwIjoxNzUxNDY1NTkyLCJpYXQiOjE3MTk5Mjk1OTQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcyNjYifQ.TPxAd1URP_-e_dVNSRpCR3a7N4N-jD6FUFuiTlPh_is";
    
    //without scope
    public const string DATA_ACCESS_TOKEN_FORBIDDEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImIwNzg4ZDJmLTgwMDMtNDNjMS05MmE0LWVkYzc2YTdjNWRkZSIsInN1YiI6ImIwNzg4ZDJmLTgwMDMtNDNjMS05MmE0LWVkYzc2YTdjNWRkZSIsImp0aSI6ImRlNDM5MzBkIiwic2NvcGUiOlsicHJvZmlsZSIsIm9wZW5pZCIsIm9mZmxpbmVfYWNjZXNzIl0sImF1ZCI6InNmYy5kYXRhIiwibmJmIjoxNzE5OTI5NzQwLCJleHAiOjE3NTE0NjU3NDAsImlhdCI6MTcxOTkyOTc0MiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzI2NiJ9.1v5PxF_ZWHYtlj4bhEyfguZ8tYNVDkgjy3eYoeD_hWM";
}
