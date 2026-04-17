const students = [
  { "name": "Ivan", "age": 18, "grade": 5.50, "city": "Sofia" },
  { "name": "Maria", "age": 17, "grade": 6.00, "city": "Plovdiv" },
  { "name": "Georgi", "age": 19, "grade": 4.20, "city": "Varna" },
  { "name": "Elena", "age": 18, "grade": 5.80, "city": "Razgrad" },
  { "name": "Petar", "age": 16, "grade": 3.90, "city": "Ruse" },
  { "name": "Desi", "age": 18, "grade": 4.90, "city": "Razgrad" }
];
const studentsGrid = document.getElementById("studentsGrid");


function renderStudents(data){
    studentsGrid.innerHTML = data.map(s=>
        `<div class="student-card">
            <h3>${s.name}</h3>
            <p><strong>Възраст:</strong>${s.age}</p>
              <p><strong>Оценка:</strong>${s.grade}</p>
                <p><strong>Град:</strong>${s.city}</p>
        </div>
   ` ).join("");
  renderStats(data);

}


document.getElementById("allBtn").addEventListener("click", () => {
  renderStudents(students);
});
