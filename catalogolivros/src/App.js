import React, { useState, useEffect } from "react";

import "./App.css";

import "bootstrap/dist/css/bootstrap.min.css";

import axios from "axios";

import { Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";

import logoLivros from "./assets/livros.jpg";

var moment = require("moment"); //

function App() {
    const baseUrl = "https://localhost:44313/api/Livros";

    const [data, setData] = useState([]);
    const [modalIncluir, setModalIncluir] = useState(false);
    const [modalEditar, setModalEditar] = useState(false);

    const [livroSelecionado, setLivroSelecionado] = useState({
        id: "",
        nome: "",
        autor: "",
        data: "",
        genero: "",
    });

    const selecionarLivro = (livro, opcao) => {
        setLivroSelecionado(livro);
        opcao === "Editar" && abrirFecharModalEditar();
    };

    const abrirFecharModalIncluir = () => {
        setModalIncluir(!modalIncluir);
    };

    const abrirFecharModalEditar = () => {
        setModalEditar(!modalEditar);
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setLivroSelecionado({ ...livroSelecionado, [name]: value });
        console.log(livroSelecionado);
    };

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

    const pedidoPost = async () => {
        delete livroSelecionado.id;

        const dataFormatada = moment(livroSelecionado.data).format(
            "YYYY-MM-DD"
        );

        livroSelecionado.data = dataFormatada;
        await axios
            .post(baseUrl, livroSelecionado)
            .then((response) => {
                setData(data.concat(response.data));
                abrirFecharModalIncluir();
            })
            .catch((error) => {
                console.log(error);
            });
    };

    const pedidoPut = async () => {
        await axios
            .put(baseUrl + "/" + livroSelecionado.id, livroSelecionado)
            .then((response) => {
                var resposta = response.data;
                var dadosAuxiliar = data;
                dadosAuxiliar.map((livro) => {
                    if (livro.id === livroSelecionado.id) {
                        livro.nome = resposta.nome;
                        livro.autor = resposta.autor;
                        livro.data = resposta.data;
                        livro.genero = resposta.genero;
                    }
                });
                abrirFecharModalEditar();
            })
            .catch((error) => {
                console.log(error);
            });
    };

    useEffect(() => {
        pedidoGet();
    });

    return (
        <div className="livro-container">
            <br />
            <h3>Cadastro de livros</h3>
            <header>
                <img src={logoLivros} alt="Livros" width="100" height="100" />
                <button
                    className="btn btn-success"
                    onClick={() => abrirFecharModalIncluir()}
                >
                    Incluir Novo Livro
                </button>
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

                            <td>{moment(livro.data).format("DD/MM/YYYY")}</td>
                            <td>{livro.genero}</td>
                            <td>
                                <button
                                    className="btn btn-primary"
                                    onClick={() =>
                                        selecionarLivro(livro, "Editar")
                                    }
                                >
                                    Editar
                                </button>
                                <button
                                    className="btn btn-danger"
                                    onClick={() =>
                                        selecionarLivro(livro, "Excluir")
                                    }
                                >
                                    Excluir
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <Modal isOpen={modalIncluir}>
                <ModalHeader>Incluir Livros</ModalHeader>

                <ModalBody>
                    <div className="form-group">
                        <label>Nome:</label>
                        <br />
                        <input
                            type="text"
                            className="form-control"
                            name="nome"
                            onChange={handleChange}
                        />
                        <br />
                        <label>Autor: </label>
                        <br />
                        <input
                            type="text"
                            className="form-control"
                            name="autor"
                            onChange={handleChange}
                        />
                        <br />
                        <label>Data Publicação: </label>
                        <br />
                        <input
                            type="text"
                            className="form-control"
                            name="data"
                            onChange={handleChange}
                        />
                        <br />
                        <label>Genero:</label>
                        <br />
                        <input
                            type="text"
                            className="form-control"
                            name="genero"
                            onChange={handleChange}
                        />
                        <br />
                    </div>
                </ModalBody>

                <ModalFooter>
                    <button
                        className="btn-btb-primary"
                        onClick={() => pedidoPost()}
                    >
                        Incluir
                    </button>
                    {"   "}
                    <button
                        className="btn- btn-danger"
                        onClick={() => abrirFecharModalIncluir()}
                    >
                        Cancelar
                    </button>
                </ModalFooter>
            </Modal>

            <Modal isOpen={modalEditar}>
                <ModalHeader>Editar Livros</ModalHeader>

                <ModalBody>
                    <div className="form-group">
                        <label>ID:</label>
                        <input
                            type="text"
                            className="form-control"
                            readOnly
                            value={livroSelecionado && livroSelecionado.id}
                        />
                        <br />
                        <label>Nome:</label>
                        <br />
                        <input
                            type="text"
                            className="form-control"
                            name="nome"
                            onChange={handleChange}
                            value={livroSelecionado && livroSelecionado.nome}
                        />
                        <br />
                        <label>Autor: </label>
                        <br />
                        <input
                            type="text"
                            className="form-control"
                            name="autor"
                            onChange={handleChange}
                            value={livroSelecionado && livroSelecionado.autor}
                        />
                        <br />
                        <label>Data Publicação: </label>
                        <br />
                        <input
                            type="text"
                            className="form-control"
                            name="data"
                            onChange={handleChange}
                            readOnly
                            // value={livroSelecionado && livroSelecionado.data}
                            value={
                                livroSelecionado &&
                                moment(livroSelecionado.data).format(
                                    "DD/MM/YYYY"
                                )
                            }
                        />
                        <br />
                        <label>Genero:</label>
                        <br />
                        <input
                            type="text"
                            className="form-control"
                            name="genero"
                            onChange={handleChange}
                            value={livroSelecionado && livroSelecionado.genero}
                        />
                        <br />
                    </div>
                </ModalBody>

                <ModalFooter>
                    <button
                        className="btn-btb-primary"
                        onClick={() => pedidoPut()}
                    >
                        Editar
                    </button>
                    {"   "}
                    <button
                        className="btn- btn-danger"
                        onClick={() => abrirFecharModalEditar()}
                    >
                        Cancelar
                    </button>
                </ModalFooter>
            </Modal>
        </div>
    );
}

export default App;
