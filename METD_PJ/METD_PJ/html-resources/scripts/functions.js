document.getElementById("dropdown1").onchange = function () {
    const selectedOption = document.getElementById('dropdown1').value;
    cefCustom.get_Disciplinas(selectedOption);
}


let _disciplinas = []
let _disciplinas_adicionar = []

// Função para receber a lista de disciplinas
function receberListaDisciplinas(disciplina) {
    _disciplinas = disciplina.map(dsc => dsc.Name);
    atualizarCentral()
}

// receber a lista de disciplinas não adicionadas
function receberListaDisciplinasAdicionar(disciplina) {
    _disciplinas_adicionar = disciplina.map(dsc => dsc.Name);
    atualizarModal()
}


function limparDisciplinas() {
    _disciplinas = []
    document.getElementsByClassName("centred-elements")[0].innerHTML = "";
}

function atualizarCentral() {

    document.getElementsByClassName("centred-elements")[0].innerHTML = "";

    for (var i = 0; i < _disciplinas.length; i++) {
        let newElement = document.createElement("div")
        newElement.className = "box-element";

        //adicionando imagem de exclusao
        var remove_div = document.createElement("div")
        remove_div.className = "remove-icon"
        var remove_div_img = document.createElement("img");
        remove_div_img.setAttribute("src", "C:/Users/Desenvolvimento/Desktop/facul/winfomrs/METD_PJ/METD_PJ/html-resources/imgs/cross_icon.png");
        remove_div.appendChild(remove_div_img)

        //adicionando imagem de disciplina
        var discipline_image = document.createElement("img")
        discipline_image.setAttribute("src", "C:/Users/Desenvolvimento/Desktop/facul/winfomrs/METD_PJ/METD_PJ/html-resources/imgs/book_img.png");

        //adicionando titulo
        var discipline_title = document.createElement("h5")
        discipline_title.innerText = _disciplinas[i];

        newElement.appendChild(remove_div)
        newElement.appendChild(discipline_image)
        newElement.appendChild(discipline_title)

        document.getElementsByClassName("centred-elements")[0].appendChild(newElement)
    }
}

function atualizarModal() {
    const dropdown_modal = document.getElementById("dropdown_modal")
    dropdown_modal.innerHTML = "";

    for (var i = 0; i < _disciplinas_adicionar.length; i++) {
        let opt = document.createElement("option");
        opt.innerHTML = _disciplinas_adicionar[i];
        opt.setAttribute("value", _disciplinas_adicionar[i]);
        dropdown_modal.appendChild(opt);
    }

}