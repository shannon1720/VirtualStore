function LogOut(){
    var email = sessionStorage.getItem("email");
    var rol = sessionStorage.getItem("rol");

    sessionStorage.removeItem("email");
    sessionStorage.removeItem("rol");

    window.location.href = "http://localhost:52014/";

    console.log(sessionStorage.getItem("email"));
    console.log(sessionStorage.getItem("rol"));

};