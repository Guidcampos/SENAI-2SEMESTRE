// const somar =(x, y) => {
//     return x + y;
// }

// const dobro = (n) => {
//     return n * 2 
// }

// const dobro1 = n => {
//     return n * 2 
// }

// const dobro2 = n => n * 2;



// console.log(somar(10,30));
// console.log(dobro(80));
// console.log(dobro1(50));
// console.log(dobro2(40));

const convidados = [
    {nome : "Carlos", idade : 36},
    {nome : "Claiton", idade : 43},
    {nome : "Rebeca", idade : 16},
    {nome : "Magalhaes", idade : 18},
    {nome : "Lucca", idade : 18},
    {nome : "Guilherme", idade : 18},
   ];

convidados.forEach(p => {
    console.log(`Convidado : ${p.nome} ${p.idade} anos`);
})