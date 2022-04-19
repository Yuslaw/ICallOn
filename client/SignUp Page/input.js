var x = document.getElementById("email");
var a = document.getElementById("userName");
var b = document.getElementById("password");
var y = document.getElementById("password2");
var spn = document.getElementById("error-message");

function build(x,a,y,b){
    return x.value.trim()==""|| a.value.trim()==""|| b.value.trim()==""|| y.value.trim()==""
}

let sub = document.getElementById("bb");
sub.addEventListener('click', function(){
    if(build(x,a,b,y))
    {
        spn.classList.remove('hidden');
        spn.innerText="wrong input format";
        // console.log("wrong input format")
    }

})