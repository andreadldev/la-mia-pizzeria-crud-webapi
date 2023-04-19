
const postPost = post => axios
    .post("/api/pizza", post)
    .then(() => location.href = "/pizza/apiindex");

const initCreateForm = () => {
    const form = document.querySelector("#post-create-form");

    form.addEventListener("submit", e => {
        e.preventDefault();

        const post = getPostFromForm(form);
        postPost(post);
    });
};

const getPostFromForm = form => {
    const name = form.querySelector("#name").value;
    const description = form.querySelector("#description").value;
    const img = form.querySelector("#image-url").value;
    const price = form.querySelector("#price").value;
    const category = form.querySelector("#categoryid").value;

    return {
        id: 0,
        name,
        description,
        img,
        price,
        category
    };
};

//const renderErrors = errors => {
//    const titleErrors = document.querySelector("#title-errors");
//    const descriptionErrors = document.querySelector("#description-errors");
//    const categoryIdErrors = document.querySelector("#category-id-errors");

//    titleErrors.innerText = errors.Title?.join("\n") ?? "";
//    descriptionErrors.innerText = errors.Description?.join("\n") ?? "";
//};