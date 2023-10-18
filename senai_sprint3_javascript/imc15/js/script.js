const listaPessoas = []; // lista vazia
let now = new Date();

function calcular(e) {
    e.preventDefault(); //capturar o evento de submit


    let nome = document.getElementById("nome").value.trim();
    let altura = parseFloat(document.getElementById("altura").value);
    let peso = parseFloat(document.getElementById("peso").value);

    if (isNaN(altura) || isNaN(peso) || nome.length < 2) {
        alert("É necessario prencher todos os campos corretamente")
        return;

    }
    const imc = calcularIMC(peso, altura);
    const situacao = geraSituacao(imc);

    // console.log(nome);
    // console.log(altura);
    // console.log(peso);
    // console.log(imc);
    // console.log(situacao);

    //object short sintaxe
    //objeto literal
    const pessoa = {
        nome,
        altura,
        peso,
        imc,
        situacao,
        dataCadastro: `${now.getDate()}/${now.getMonth() + 1}/${now.getFullYear()} ${now.getHours()}:${now.getMinutes()}`
    }

    // console.log(pessoa);

    //insera uma pessoa no array
    listaPessoas.push(pessoa);

    exibirDados();

    limparForm();

    // document.getElementById("nome").value = "";
    // document.getElementById("altura").value = "";
    // document.getElementById("peso").value = "";
}

function limparForm() {
   
    document.getElementById("nome").value = "";
    document.getElementById("altura").value = "";
    document.getElementById("peso").value = "";
    
}
    



function calcularIMC(peso, altura) {
    return peso / Math.pow(altura, 2);
}

function geraSituacao(imc) {

    if (imc < 18.5) {
        return 'Magreza Severa';
    } else if (imc <= 24.99) {
        return 'Peso normal';
    } else if (imc <= 29.99) {
        return "Acima do peso";
    } else if (imc <= 34.99) {
        return 'Obesidade I';
    } else if (imc <= 39.99) {
        return 'Obesidade II';
    } else {
        return 'Cuidado!';
    }

}

function exibirDados() {
    //listar a lista de pessoas


    let linhas = '';
    listaPessoas.forEach(function (oPessoa) {
    linhas += `
        <tr>
            <td data-cell="nome">${oPessoa.nome}</td>
            <td data-cell="altura">${oPessoa.altura}</td>
            <td data-cell="peso">${oPessoa.peso}</td>
            <td data-cell="valor do IMC">${oPessoa.imc.toFixed(2)}</td>
            <td data-cell="classificação do IMC">${oPessoa.situacao}</td>
            <td data-cell="data de cadastro">${oPessoa.dataCadastro}</td>
        </tr>
    `;
    });
    document.getElementById("corpo-tabela").innerHTML = linhas;
}

