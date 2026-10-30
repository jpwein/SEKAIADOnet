// Роутинг и логика запросов
document.addEventListener("DOMContentLoaded", () => {
    fetch('/students/all')
        .then(response => response.json())
        .then(data => {
            console.log("Получены студенты:", data);
        });
});
