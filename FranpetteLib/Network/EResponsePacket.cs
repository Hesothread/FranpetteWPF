using System;
using System.Collections.Generic;
using System.Text;

namespace FranpetteLib.Network
{
    public enum EResponsePacket
    {
        SERV_CONECTED = 100,  // + server_version + server_name
        SERV_DISCONECTED = 101,  //
        SERVER_ERROR = 103,  // + error_code

        AUTH_CONNECT = 200,  // + current_user_id
        AUTH_DISCONNECTED = 201,  //

        USER_INFO = 300,  // + user_id + user_name + user_state + user_description + user_ip
        APPLICTION_INFO = 400,  // + app_id + app_name + app_desc + app_state + started_user_id + started_date + started_ip + last_user_id + last_date + app_version + owner_id + owner_date
        SERVER_INFO = 500   // + server_name + client_news + client_news_id + client_version
    }
}
