const checkboxesTipo = document.querySelectorAll('.filtroTipo');
const checkboxesMarca = document.querySelectorAll('.filtroMarca');

function marcarCaixas(caixas) {
    switch (caixas) {
        case "playstation":
            document.getElementsByName('cbmsony')[0].checked = true;
            break;

        case "xbox":
            document.getElementsByName('cbmxbox')[0].checked = true;
            break;

        case "informatica":
            document.getElementsByName('cbnotebook')[0].checked = true;
            document.getElementsByName('cbcomputador')[0].checked = true;
            document.getElementsByName('cbhardware')[0].checked = true;
            document.getElementsByName('cbacessorio')[0].checked = true;
            break;

        case "smartphone":
            document.getElementsByName('cbsmartphone')[0].checked = true;
            break;

        default:
            break;
    }
}


marcarCaixas(caixas);




checkboxesTipo.forEach(cb => cb.addEventListener('change', filtrarProdutos));
checkboxesMarca.forEach(cb => cb.addEventListener('change', filtrarProdutos));

function filtrarProdutos() {
    const tiposSelecionados = Array.from(checkboxesTipo)
        .filter(cb => cb.checked)
        .map(cb => cb.value);

    const marcasSelecionadas = Array.from(checkboxesMarca)
        .filter(cb => cb.checked)
        .map(cb => cb.value);

    document.querySelectorAll('.containerdoproduto').forEach(produto => {
        const tipo = produto.getAttribute('data-tipo');
        const marca = produto.getAttribute('data-mark');

        const tipoMatch = tiposSelecionados.length === 0 || tiposSelecionados.includes(tipo);
        const marcaMatch = marcasSelecionadas.length === 0 || marcasSelecionadas.includes(marca);

        if (tipoMatch && marcaMatch) {
            produto.style.display = 'block';
        } else {
            produto.style.display = 'none';
        }
    });
}

// Executar filtro ao carregar a página (caso haja algum marcado por padrão)
window.addEventListener('DOMContentLoaded', filtrarProdutos);
