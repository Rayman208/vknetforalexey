using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Properties;
using VkNet.Utils;
using VkNet.Enums;


namespace vkbot1
{
    class Program
    {
        static void Main(string[] args)
        {
            VkApi api = new VkApi();
            #region скрытый
            ApiAuthParams authParams = new ApiAuthParams();
            authParams.Login = "+79006906308";
            authParams.Password = "";//не скажу
            authParams.Settings = Settings.All;
            authParams.ApplicationId = 5963990;
            #endregion
            api.Authorize(authParams);
            if (api.IsAuthorized == false)
            {
                Console.WriteLine("IsAuthorized = false");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("IsAuthorized = true");
            }

            GroupsGetMembersParams param = new GroupsGetMembersParams();
            param.GroupId = "itpark32";
            //param.Fields = UsersFields.Nickname| UsersFields.Sex; доп параметры

            long currentCount = 0;
            VkCollection<User> users = null;
            do
            {
                param.Offset = currentCount;//потому что по 1000 за раз выбирает
                users = api.Groups.GetMembers(param);
                Console.WriteLine("кол-во людей в группе = {0}", users.TotalCount);
                foreach (User item in users)
                {
                    Console.WriteLine("{0} = {1}", ++currentCount, item.Id);
                }
            } while (currentCount < (long)users.TotalCount);

            Console.ReadKey();
        }
    }
}
