import { useEffect, useState } from "react";

function Dashboard() {
  const [tasks, setTasks] = useState([]);
  const [newTask, setNewTask] = useState("");

  const fetchTasks = async () => {
    const res = await fetch("http://localhost:5000/tasks");
    const data = await res.json();
    setTasks(data);
  };

  useEffect(() => {
    fetchTasks();
  }, []);

  const addTask = async () => {
    if (!newTask) return;

    await fetch("http://localhost:5000/tasks", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ name: newTask, isCompleted: false }),
    });

    setNewTask("");
    fetchTasks();
  };

  const toggleTask = async (task) => {
    await fetch(`http://localhost:5000/tasks/${task.id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        name: task.name,
        isCompleted: !task.isCompleted,
      }),
    });

    fetchTasks();
  };

  return (
    <div style={{ padding: "40px", fontFamily: "Arial" }}>
      <h1>☁️ Cloud App Dashboard</h1>

      <input
        type="text"
        placeholder="Wpisz zadanie..."
        value={newTask}
        onChange={(e) => setNewTask(e.target.value)}
      />

      <button onClick={addTask}>Dodaj</button>

      <div style={{ marginTop: "20px" }}>
        {tasks.map((task) => (
          <button
            key={task.id}
            onClick={() => toggleTask(task)}
            style={{
              display: "block",
              marginBottom: "10px",
              padding: "10px",
              width: "200px",
              backgroundColor: task.isCompleted ? "#28a745" : "#007bff",
              color: "white",
              border: "none",
              textDecoration: task.isCompleted ? "line-through" : "none",
              cursor: "pointer",
            }}
          >
            {task.name}
          </button>
        ))}
      </div>
    </div>
  );
}

export default Dashboard;