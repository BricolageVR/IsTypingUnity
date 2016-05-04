#pragma strict
import SimpleJSON;
enum Handler {get_latest_chats, get_closest_persons_and_msgs, have_hebrew, get_good_night_messages, get_dreams_or_old_messages, get_most_active_groups_and_user_groups, get_chat_archive}

var handler : Handler;

private var url = "http://localHost:8888/" + handler.ToString();

function Start() {
    url = "http://localHost:8888/" + handler.ToString();
    
    var www : WWW = new WWW (url);
 
    // wait for request to complete
    yield www;
 
    // and check for errors
    if (www.error == null)
    {
        // request completed!
    } else {
        // something wrong!
        Debug.Log("WWW Error: "+ www.error);
    }
    
    var dataText = www.text;
    var data = JSON.Parse(dataText);
    Debug.Log(data);
}