import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./pages/Layout";
import Home from "./pages/Home";
import Memes from "./pages/Memes";
import Foods from "./pages/Foods";
import NoPage from "./pages/NoPage";
import './App.css';


export default function App() {
    return (
        <BrowserRouter>
            <Routes path="/" element={<Layout />}>
                <Route index element={<Home />} />
                <Route path="Memes" element={<Memes />} />
                <Route path="Foods" element={<Foods />} />
                <Route path="*" element={<NoPage />} />
            </Routes>
        </BrowserRouter>
    );
}