using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace IdentityApp.TagHelpers
{
    // Target <td> elements with the attribute asp-role-users
    [HtmlTargetElement("td", Attributes = "asp-role-users")]
    public class RoleUsersTagHelper : TagHelper
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        // Constructor to initialize RoleManager and UserManager
        public RoleUsersTagHelper(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // Attribute to hold the role name
        [HtmlAttributeName("asp-role-users")]
        public string Role { get; set; } = null!;
        
        // Process the tag helper
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var userNames = new List<string>();
            var role = await _roleManager.FindByIdAsync(Role);
            if (role != null && role.Name != null)
            {
                foreach (var user in _userManager.Users)
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        userNames.Add(user.UserName ?? "");
                    }
                }
                output.Content.SetHtmlContent(userNames.Count == 0 ? "kullanıcı yok" : setHtml(userNames));
            }
        }

        // Helper method to generate HTML content
        private string setHtml(List<string> userNames)
        {
            var html = "<ul>";
            foreach (var item in userNames)
            {
                html += "<li>" + item + "</li>";
            }
            html += "</ul>";
            return html;
        }
    }
}
