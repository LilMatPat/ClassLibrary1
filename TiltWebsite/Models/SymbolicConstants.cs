using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiltWebsite.Models
{ 
public static class SymbolicConstants
{
    public const int AdminRole = 1;
    public const string AdminRoleName = "   ";

    public const int PowerRole = 2;
    public const string PowerRoleName = "Lord";

    public const int NormalRole = 3;
    public const string NormalRoleName = "Knight";

    public const int DefaultDefaultPageSize = 3;
    public const int DefaultPageNumber = 0;
    public const int MinPasswordLength = 6;
    public const int MaxPasswordLength = 18;
    public const int SaltSize = 20;
    public const string PasswordRequirementsMessage = "The Password must contain at Least One Capital letter, One Lowercase letter and One Number";
    public const string PasswordRequirements = @"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$";
}
}