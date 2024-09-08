import './App.css'
import GetAllFruits from "./Components/GetAllFruits.tsx";
import CreateFruit from "./Components/CreateFruit.tsx";
import UpdateFruit from "./Components/UpdateFruit.tsx";

function App() {


  return (
    <>
        <h1> Costumer! </h1>
        <GetAllFruits />
        <CreateFruit />
        <UpdateFruit />
    </>
  )
}

export default App
