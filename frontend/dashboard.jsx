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
      body: JSON.stringify({ name: newTask }),
    });

    setNewTask("");
    fetchTasks();
  };

  return (
    <div style={{ padding: "40px" }}>
      <h1>☁️ Cloud App Dashboard</h1>

      <input
        type="text"
        placeholder="Wpisz zadanie..."
        value={newTask}
        onChange={(e) => setNewTask(e.target.value)}
      />

      <button onClick={addTask}>Dodaj</button>

      {tasks.map((task) => (
        <div key={task.id}>{task.name}</div>
      ))}
    </div>
  );
}

export default Dashboard;