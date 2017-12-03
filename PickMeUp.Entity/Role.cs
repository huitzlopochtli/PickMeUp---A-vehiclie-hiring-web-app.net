using Microsoft.AspNet.Identity.EntityFramework;


namespace PickMeUp.Entity
{
    public class Role : IdentityRole
    {
        public Role()
            :base()
        {

        }

        public Role(string roleName) 
            :base(roleName)
        {
        }


    }
}
