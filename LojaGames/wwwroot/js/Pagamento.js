const inputCartao = document.getElementById("numerocartao");
const resultado = document.getElementById("Banco");
const logobandeira = document.getElementById("bande");
const saida = document.getElementById("saida");

inputCartao.addEventListener("input", () => {

    const numero = inputCartao.value.replace(/\D/g, '');
    const bandeira = detectarBandeira(numero);

    TrocarBandeira(bandeira);


});

function TrocarBandeira(a) {

    switch (a) {
        case "Visa":
            alert('visa');
            logobandeira.src = "/assets/image/icones/visa.svg";

            break;

        case "MasterCard":
            alert("master");
            logobandeira.src = "/assets/image/icones/mastercard.svg";
            break;

        case "American Express":

            logobandeira.src = "/assets/image/icones/americaexpress.svg";
            break;

        case "Diners Club / Hipercard":

            logobandeira.src = "/assets/image/icones/icons8-diners-club.svg";
            break;

        case "Discover":

            logobandeira.src = "/assets/image/icones/discovery.svg";
            break;

        case "Elo":

            logobandeira.src = "/assets/image/icones/elologo.png";
            break;

        case "Hipercard":

            logobandeira.src = "/assets/image/icones/hipercardlogo.png";
            break;

        default:
            logobandeira.src = "/assets/image/icones/cartaoazu.png";

            break;
    }
}


function detectarBandeira(numero) {
    if (/^4[0-9]{5}/.test(numero)) return "Visa"; else
    if (/^5[1-5][0-9]{4}/.test(numero) || /^2(2[2-9]|[3-6][0-9]|7[01])[0-9]{3}/.test(numero)) return "MasterCard";else
    if (/^3[47][0-9]{4}/.test(numero)) return "American Express";
    if (/^3(6|8)/.test(numero)) return "Diners Club / Hipercard";
    if (/^6011|65[0-9]{2}|64[4-9][0-9]/.test(numero)) return "Discover";
    if (/^5067|5090|6277|6363|6504/.test(numero)) return "Elo";
    if (/^606282|3841/.test(numero)) return "Hipercard";
    return "Bandeira desconhecida";
}