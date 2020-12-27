using CheckSeparatorMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace CheckSeparatorMVC.Data
{
    public static class DbManipulator
    {
        public static List<Check> GetUserChecks(CheckSeparatorMvcContext context, string userId)
        {
            var checkIds = context.checkUsers
                .Where(cu => cu.UserId == userId)
                .Select(c => c.CheckId)
                .ToList();

            var checks = context.Checks.Where(c => checkIds.Contains(c.CheckId));
            return checks.ToList();
        }
    }
}
