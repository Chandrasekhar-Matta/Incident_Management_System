import { BrowserRouter, Routes, Route } from "react-router-dom";
import Dashboard from "./pages/Dashboard";
import Detail from "./pages/Detail";
import RCAForm from "./pages/RCAForm";

function App() {

    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Dashboard />} />
                <Route path="/detail/:id" element={<Detail />} />
                <Route path="/rca/:id" element={<RCAForm />} />
            </Routes>
        </BrowserRouter>

    );

}

export default App;