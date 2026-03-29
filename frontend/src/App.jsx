import { useEffect, useState } from "react";

const API = "https://cloud-app-backend-wiktoria-eygcfm6crhxfcve.germanywestcentral-01.azurewebsites.net/tasks";

function App() {
  const [tasks, setTasks] = useState([]);
  const [text, setText] = useState("");

  const loadTasks = async () => {
    const res = await fetch(API);
    const data = await res.json();
    setTasks(data);
  };

  const addTask = async () => {
    await fetch(API, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ name: text, isCompleted: false }),
    });

    setText("");
    loadTasks();
  };

  useEffect(() => {
    loadTasks();
  }, []);

  return (
    <div style={{ padding: 20 }}>
      <h1>Moje zadania</h1>

      <input
        value={text}
        onChange={(e) => setText(e.target.value)}
        placeholder="Wpisz zadanie"
      />
      <button onClick={addTask}>Dodaj</button>

      <ul>
        {tasks.map((t) => (
          <li key={t.id}>
            {t.name} {t.isCompleted ? "✅" : ""}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;