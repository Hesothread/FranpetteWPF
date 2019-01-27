using System;
using System.Collections.Generic;
using System.Text;

namespace FranpetteLib.Network
{
    public enum ERequestPacket
    {
        SERV_CONECT = 10,   // + version
        SERV_DISCONECT = 11,   // + 

        AUTH_LOGIN = 20,   // + login [+ password]
        AUTH_LOGOUT = 21,   // + current_user_id

        USER_GETLIST = 30,   // + current_user_id
        USER_GET = 31,   // + current_user_id + user_id
        USER_SET = 32,   // + current_user_id + user_id + user_name + user_description + user_state + user_ip

        APPLICATION_GETLIST = 40,   // + current_user_id
        APPLICATION_GET = 41,   // + current_user_id + application_id
        APPLICATION_SET = 42,   // + current_user_id + application_id + application_name + application_description + application_state + user_start_id + user_start_ip + application_client_version + application_started_date + owner_id + owner_creation_date + last_user_id + last_user_date
        APPLICATION_GETHEADER = 43,    // + current_user_id + application_id

        INFO_GET = 50,   // + current_user_id
        INFO_SET = 51    // + current_user_id + server_id + server_name + server_description + news_owner_id + news*
    }
}
