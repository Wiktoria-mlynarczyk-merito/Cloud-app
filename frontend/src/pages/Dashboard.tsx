import { useEffect, useState } from "react"
import axios from "axios"

function Dashboard() {

  const [tasks, setTasks] = useState<string[]>([])

  useEffect(() => {
    axios.get("http://localhost:5115/tasks")
      .then(res => {
        setTasks(res.data)
      })
      .catch(err => console.error(err))
  }, [])

  return (
    <div style={{ padding: "40px" }}>
      <h1>Cloud App Dashboard</h1>

      <h2>Tasks from API</h2>

      <ul>
        {tasks.map((task, index) => (
          <li key={index}>{task}</li>
        ))}
      </ul>
    </div>
  )
}

export default Dashboard
