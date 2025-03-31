
document.write(
    `
    <nav class="menu">
        <ul id="menul">
        </ul>
    </nav>
    `
)

const actual_page = document.title;
var allPages = ["Aulas", "Disciplinas"]
var refs = ["index.html", "disciplines.html"]

//primeiro elemento
const element = document.createElement('li')
element.innerHTML = actual_page
document.getElementById("menul").appendChild(element)

var indexer = allPages.indexOf(actual_page)
allPages[indexer] = null
refs[indexer] = null

//remanecentes
for (var i = 0; i < allPages.length; i++) {

    if (allPages[i] !== null) {
        const element = document.createElement('li')
        const _li = document.createElement("a")
        _li.setAttribute('href', refs[i])
        _li.innerHTML = allPages[i]
        element.appendChild(_li)
        document.getElementById("menul").appendChild(element)
    }

    
}