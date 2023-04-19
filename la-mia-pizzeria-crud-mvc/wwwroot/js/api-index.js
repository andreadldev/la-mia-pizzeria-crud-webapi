const loadPizzas = filter => getPizzas(filter).then(renderPizzas);

const getPizzas = title => axios
    .get('/api/pizza', name ? { params: { name } } : {})
    .then(res => res.data);

const renderPizzas = pizzas => {
    const emptyMessage = document.querySelector("#emptyMessage");
    const loader = document.querySelector("#loader");
    const tbody = document.querySelector("#pizzaList");
    const table = document.querySelector("#table");
    //const filter = document.querySelector("#filter");

    if (pizzas && pizzas.length > 0) {
        table.style.display = "block";
        //filter.style.display = "block";
        emptyMessage.style.display = "none";
    }
    else emptyMessage.style.display = "block";

    loader.style.display = "none";

    tbody.innerHTML = pizzas.map(pizzaComponent).join('');
};

//const initFilter = () => {
//    const filter = document.querySelector("#filter input");
//    filter.addEventListener("keyup", (e) => loadPizzas(e.target.value))
//};

const pizzaComponent = pizza => `
    <tr>
        <td>${pizza.id}</td>
        <td><img class="rounded-circle" width="80" src="${pizza.img}"></td>
        <td>${pizza.name}</td>
        <td>${pizza.description}</td>
    </tr>`;