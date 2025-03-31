document.addEventListener('contextmenu', event => event.preventDefault());

//filtro de pesquisa **lembrete para deixa-lo dinamico conforme a mudanca de pagina
document.write(`
            <div class="search-filter">

                <!-- BARRA DE PESQUISA -->
                <input type="text" class="search-bar" placeholder="Pesquisar">

                <!-- FILTRO DE TIPO -->
                <select id="dropdown1">
                </select>

                <!-- FILTRO DE ORDENAÇÃO -->
                <select class="filter-dropdown">
                    <option value="recente">Mais Recente</option>
                    <option value="antigo">Mais Antigo</option>
                </select>
            </div>
`)


var allPages = ["Aulas", "Disciplinas"]
let _Add_elements = []


// Função para preencher o dropdown com os elementos
function preencherDropdown() {
    const dropdown = document.getElementById("dropdown1");

    // Limpar o dropdown antes de adicionar novos itens
    dropdown.innerHTML = "";

    const opt = document.createElement("option");
    opt.innerHTML = "Escolher";
    opt.setAttribute("value", "empty");
    dropdown.appendChild(opt);

    // Adiciona as opções ao dropdown
    for (var i = 0; i < _Add_elements.length; i++) {
        const opt = document.createElement("option");
        opt.innerHTML = _Add_elements[i];
        opt.setAttribute("value", _Add_elements[i]);
        dropdown.appendChild(opt);
    }
}

// Função para receber a lista de cursos do backend
function receberLista(cursos) {
    _Add_elements = cursos.map(cr => (cr.Name + " (" + cr.Id + ")").toString());
    preencherDropdown();
}

// Função para receber a filtro-geral
function receberFiltroGeral(filtro) {
    _Add_elements = filtro.map(ft => ft.toString());
    preencherDropdown();
}


switch (actual_page) {
    case allPages[0]:
        cefCustom.get_Filtro_Geral();
        break;
    case allPages[1]:
        cefCustom.get_Cursos();
        break;
}


