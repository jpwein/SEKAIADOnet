import pyodbc

# Урок 2 — Python + pyodbc
connection_str = (
    "DRIVER={ODBC Driver 17 for SQL Server};"
    "SERVER=localhost;"
    "DATABASE=CollegeDB;"
    "Trusted_Connection=yes;"
)

try:
    with pyodbc.connect(connection_str) as conn:
        cursor = conn.cursor()
        cursor.execute("SELECT Id, FirstName, LastName FROM Students")
        print("--- Список студентов (Python + pyodbc) ---")
        for row in cursor.fetchall():
            print(f"ID: {row.Id} | Имя: {row.FirstName} {row.LastName}")
except Exception as ex:
    print(f"Ошибка подключения: {ex}")
