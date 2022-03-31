import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import Home from "./Home";
import Autores from "./Autores";
import Generos from "./Generos";

const Rotas = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route exact path="/" element={<Home />} />
                <Route element={<Autores />} path="/autores" />
                <Route element={<Generos />} path="/generos" />
            </Routes>
        </BrowserRouter>
    );
};

export default Rotas;
