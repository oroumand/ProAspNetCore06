window.addEventListener("DOMContentLoaded", () => {
    document.querySelectorAll("input.input-validation-error").forEach((elm) => {
        elm.classList.add("is-invalid");
    });
});