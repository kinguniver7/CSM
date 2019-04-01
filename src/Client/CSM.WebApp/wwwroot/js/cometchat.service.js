"use strict";

var CometChatService = function () {
  var apiKey,
      appId,
      uId,
    sessionId;

  var callType = CometChat.CALL_TYPE.VIDEO;
  var receiverType = CometChat.RECEIVER_TYPE.USER;
  var call;
  var receiverId;

  var user;
  var callListnerId = "CALL_LISTENER_ID_" + uId;

  var init = function () {    
    if (CometChat) {
      CometChat.init(appId).then(
        hasInitialized => {
          console.log("Initialization completed successfully", hasInitialized);
          //You can now call login function.  
          login(); 
        },
        error => {
          console.log("Initialization failed with error:", error);
          //Check the reason for error and take apppropriate action.
        }
      );
    }
  }

  var login = function () {
    CometChat.login(uId, apiKey).then(
      User => {
        console.log("Login Successful:", { User });
        // User loged in successfully.
        user = User;
        addCallListener();
      },
      error => {
        console.log("Login failed with exception:", { error });
        // User login failed, check error and take appropriate action.
      }
    );
  }

  var initiateCall = function () {
    call = new CometChat.Call(receiverId, callType, receiverType);
    
    CometChat.initiateCall(call).then(
      outGoingCall => {
        alert("Call initiated successfully:");
        // perform action on success. Like show your calling screen.
      },
      error => {
        console.log("Call initialization failed with exception:", error);
      }
    );
  }
  var addCallListener = function () {
    CometChat.addCallListener(
      callListnerId,
      new CometChat.CallListener({
        onIncomingCallReceived(call) {
          var res = confirm("Incoming call?");
          if (res) {
            CometChat.acceptCall(call.sessionId).then(
              call => {

                CometChat.startCall(
                  call.sessionId,
                  document.getElementById("callScreen"),
                  new CometChat.OngoingCallListener({
                    onUserJoined: user => {
                      /* Notification received here if another user joins the call. */
                      console.log("User joined call:", user);
                      /* this method can be use to display message or perform any actions if someone joining the call */
                    },
                    onUserLeft: user => {
                      /* Notification received here if another user left the call. */
                      console.log("User left call:", user);
                      /* this method can be use to display message or perform any actions if someone leaving the call */
                    },
                    onCallEnded: call => {
                      /* Notification received here if current ongoing call is ended. */
                      console.log("Call ended:", call);
                      /* hiding/closing the call screen can be done here. */
                    }
                  })
                );


              },
              error => {
                console.log("Call acceptance failed with error", error);
                // handle exception
              }
            );

          }else{
            CometChat.rejectCall(call.sessionId.sessionId, CometChat.CALL_STATUS.REJECTED).then(
              call => {
                console.log("Call rejected successfully", call);
              },
              error => {
                console.log("Call rejection failed with error:", error);
              }
            );
          }
          // Handle incoming call
        },
        onOutgoingCallAccepted(call) {
          console.log("Outgoing call accepted:", call);
          // Outgoing Call Accepted
        },
        onOutgoingCallRejected(call) {
          console.log("Outgoing call rejected:", call);
          // Outgoing Call Rejected
        },
        onIncomingCallCancelled(call) {
          console.log("Incoming call calcelled:", call);
        }
      })
    );
  }
  var destroy = function () {
    CometChat.removeCallListener(listenerId);
  }
  return{
    _init: function (app_Id, api_Key, u_Id) {
      appId = app_Id;
      apiKey = api_Key;
      uId = u_Id;
      init();

      window.onbeforeunload = (function () {
        destroy();
      });
      
    },
    _login: function () {
      login(); 
    },
    _videoCall: function (receiver_Id) {
      receiverId = receiver_Id;
      initiateCall();
    },
    _getUser: function () {
      return user;
    }

  };
}();