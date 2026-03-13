import axios from "axios";
import { useEffect, useState } from "react";

function App() {

  const [data, setData] = useState<string[]>([]);

  useEffect(() => {
    axios.get(import.meta.env.VITE_API_URL)
      .then(res => setData(res.data))
      .catch(err => console.log(err));
  }, []);

  return (
    <div>
      <h1>Dane z API</h1>
      <ul>
        {data.map((item, index) => (
          <li key={index}>{item}</li>
        ))}
      </ul>
    </div>
  );
}

export default App;