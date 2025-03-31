document.write(`
           <div class="modal" id="myModal">
                <button onclick="close_Modal_Discipline_Curso()" class="modal-close">x</button>
                <div class="modal-header">
                    <h4>Adicionar Disciplina</h4>
                </div>
                <div class="modal-body">
                    <select id="dropdown_modal" style="width: 100%; padding: 10px; border-radius: 5px; border: 1px solid #ccc;">
                    <option>Selecione</option>
                    </select>
                </div>
                <div class="modal-footer">
                    <!-- Input e Botão -->
                    <!--<input type="text" id="inputField" placeholder="Digite algo..." />-->
                    <button onclick="cadastro()">Adicionar</button>
                </div>
            </div>
`)

function open_Modal_Add_Discipline_Curso() {
    document.getElementsByClassName('content')[0].classList.add('blurred');

    document.getElementsByClassName('modal')[0].style.display = 'flex';
    var selectedOption = document.getElementById('dropdown1').value;

    cefCustom.get_Disciplinas_Curso(selectedOption);
}

function close_Modal_Discipline_Curso() {
    document.getElementsByClassName('content')[0].classList.remove('blurred');
    document.getElementById('myModal').style.display = 'none';
}

_contentElement = document.getElementsByClassName('content')[0]
_searchElement = document.getElementsByClassName('search-filter')[0]

_contentElement.childNodes.forEach(x => {
    x.addEventListener('click', function (event) {
        if (event.target === x) {
            close_Modal_Discipline_Curso();
        }
    })
});

_contentElement.addEventListener('click', function (event) {
        // Verifica se o clique foi fora do modal (ou seja, no fundo)
    if (event.target === _contentElement) {
            close_Modal_Discipline_Curso();
    }
});


_searchElement.childNodes.forEach(x => {
    x.addEventListener('click', function (event) {
        if (event.target === x) {
            close_Modal_Discipline_Curso();
        }
    })
});

_searchElement.addEventListener('click', function (event) {
    // Verifica se o clique foi fora do modal (ou seja, no fundo)
    if (event.target === _searchElement) {
            close_Modal_Discipline_Curso();
    }
});