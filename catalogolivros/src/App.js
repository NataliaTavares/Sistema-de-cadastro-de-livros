import React, { useState, useEffect } from "react";

import "./App.css";

import "bootstrap/dist/css/bootstrap.min.css";

import axios from "axios";

import { Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";

import logoLivros from "./assets/livros.jpg";

function App() {
    const baseUrl = "https://localhost:44313/api/Livros";

    const [data, setData] = useState([]);

    const pedidoGet = async () => {
        await axios
            .get(baseUrl)
            .then((response) => {
                setData(response.data);
            })
            .catch((error) => {
                console.log(error);
            });
    };

    useEffect(() => {
        pedidoGet();
    });

    return (
        <div className="App">
            <br />
            <h3>Cadastro de livros</h3>
            <header>
                <img src={logoLivros} alt="Livros" width="100" height="100" />
                <button className="btn btn-success">Incluir Novo Livro</button>
            </header>

            <table className="table table-bordered">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Nome</th>
                        <th>Autor</th>
                        <th>Data da Publicação</th>
                        <th>Genero</th>
                        <th>Operação</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map((livro) => (
                        <tr key={livro.id}>
                            <td>{livro.id}</td>
                            <td>{livro.nome}</td>
                            <td>{livro.autor}</td>
                            <td>{livro.data}</td>
                            <td>{livro.genero}</td>
                            <td>
                                <button className="btn btn-primary">
                                    Editar
                                </button>
                                <button className="btn btn-danger">
                                    Excluir
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default App;
