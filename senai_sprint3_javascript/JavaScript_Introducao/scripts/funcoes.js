
function calcular() {
    event.preventDefault();

    let n1 = parseFloat(document.getElementById("numero1").value);
    let n2 = parseFloat(document.getElementById("numero2").value);
    let n3;
    let op = document.getElementById("op").value;

   if(isNaN(n1) || isNaN(n2)){
    alert("preencha os campos corretamente")
    return;
   }


    if (op == `+`) {
        n3 = somar(n1, n2);
        alert(`o resultado de ${n1} ${op} ${n2} é igual : ${n3}`);

    }
    else if (op == `-`) {
        n3 = subtrair(n1, n2);
        alert(`o resultado de ${n1} ${op} ${n2} é igual : ${n3}`);

    }
    else if (op == '/') {
        n3 = dividir(n1, n2);
        alert(`o resultado de ${n1} ${op} ${n2} é igual : ${n3}`);

    }
    else if (op == '*') {
        n3 = multiplicar(n1, n2);
        alert(`o resultado de ${n1} ${op} ${n2} é igual : ${n3}`);

    }
    else {
        n3 = "operação invalida"
        alert("Operação invalida");
        
    }

    console.log(n3);
    document.getElementById(`resultado`).innerText = n3
};

function somar(x, y) {

    return (x + y).toFixed(2);

}
function subtrair(x, y) {

    return (x - y).toFixed(2);

}
function dividir(x, y) {
    if (y != 0){
    return (x / y).toFixed(2);
}
else { return "impossivel dividir por 0"};

}
function multiplicar(x, y) {

    return (x * y).toFixed(2);

}
