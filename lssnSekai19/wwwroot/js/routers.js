document.addEventListener("DOMContentLoaded", () => {
    fetch('/students/all')
        .then(res => res.json())
        .then(data => console.log("EF Core Students:", data));
});
