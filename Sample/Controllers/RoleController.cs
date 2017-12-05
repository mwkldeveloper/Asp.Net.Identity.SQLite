using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Sample.Models;
using AspNet.Identity.SQLite;
using System.Web.Http;

namespace Sample.Controllers
{
    public class RoleController : ApiController
	{
		private ApplicationRoleManager _roleManager;

		public RoleController()
		{
		}

		public RoleController(ApplicationRoleManager roleManager)
		{
			RoleManager = roleManager;
		}


		public ApplicationRoleManager RoleManager
		{
			get
			{
				return _roleManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationRoleManager>();
			}
			private set
			{
				_roleManager = value;
			}
		}

		[HttpPost]
		public async Task<IHttpActionResult> Create(CreateRoleViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (!RoleManager.RoleExists(model.Name))
			{
				var result = await RoleManager.CreateAsync(new IdentityRole(model.Name));
				if (!result.Succeeded)
				{
					return BadRequest();
				}
			}
			else
			{
				return BadRequest("Already exists!!");

			}

			return Ok();
		}
	}
}
