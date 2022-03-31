import { Route, BrowserRouter } from "react-router-dom";
import { Link } from "react-router-dom";

import React, { useState, useEffect } from "react";
import "./App.css";

import "bootstrap/dist/css/bootstrap.min.css";

import axios from "axios";

import { Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";

import logoLivros from "./assets/livros.jpg";

const Home = () => {
    var moment = require("moment"); //

    const baseUrl = "https://localhost:44313/api/Livros";

    const [data, setData] = useState([]);
    const [updateData, setUpdateData] = useState(true);

    const [modalIncluir, setModalIncluir] = useState(false);
    const [modalEditar, setModalEditar] = useState(false);
    const [modalExcluir, setModalExcluir] = useState(false);

    const [livroSelecionado, setLivroSelecionado] = useState({
        id: "",
        nome: "",
        autor: "",
        data: "",
        genero: "",
    });

    const selecionarLivro = (livro, opcao) => {
        setLivroSelecionado(livro);
        opcao === "Editar"
            ? abrirFecharModalEditar()
            : abrirFecharModalExcluir();
    };

    const abrirFecharModalIncluir = () => {
        setModalIncluir(!modalIncluir);
    };

    const abrirFecharModalEditar = () => {
        setModalEditar(!modalEditar);
    };

    const abrirFecharModalExcluir = () => {
        setModalExcluir(!modalExcluir);
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

        const dataBrasileira = livroSelecionado.data;
        const dataAmericana = dataBrasileira.split("/").reverse().join("-");

        livroSelecionado.data = dataAmericana;
        await axios
            .post(baseUrl, livroSelecionado)
            .then((response) => {
                setData(data.concat(response.data));
                setUpdateData(true);
                abrirFecharModalIncluir();
            })
            .catch((error) => {
                console.log(error);
            });
    };

    const pedidoPut = async () => {
        const dataBrasileira = livroSelecionado.data;
        const dataAmericana = dataBrasileira.split("/").reverse().join("-");
        livroSelecionado.data = dataAmericana;
        await axios
            .put(baseUrl + "/" + livroSelecionado.id, livroSelecionado)
            .then((response) => {
                var resposta = response.data;
                var dadosAuxiliar = data;
                dadosAuxiliar.map((livro) => {
                    if (livro.id === livroSelecionado.id) {
                        livro.nome = resposta.nome;
                        livro.autor = resposta.autor;
                        livro.data = dataAmericana;
                        livro.genero = resposta.genero;
                    }
                });
                setUpdateData(true);
                abrirFecharModalEditar();
            })
            .catch((error) => {
                console.log(error);
            });
    };

    const pedidoDelete = async () => {
        await axios
            .delete(baseUrl + "/" + livroSelecionado.id)
            .then((response) => {
                setData(data.filter((livro) => livro.id !== response.data));
                setUpdateData(true);
                abrirFecharModalExcluir();
            })
            .catch((error) => {
                console.log(error);
            });
    };

    useEffect(() => {
        if (updateData) {
            pedidoGet();
            setUpdateData(false);
        }
    }, [updateData]);

    function ConvertDataAmericana(livroData) {
        const dataAmericana = livroData;
        const dataBrasileira = dataAmericana
            .split("-")
            .reverse()
            .join("/")
            .replace("T00:00:00", "");

        return dataBrasileira;
    }

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

            <nav>
                <ul>
                    <li>
                        <Link to="/autores">Autores</Link>
                    </li>
                    <li>
                        <Link to="/generos">Generos</Link>
                    </li>
                </ul>
            </nav>

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
                        <label>Data Publicação: </label>
                        <br />
                        <input
                            type="text"
                            className="form-control"
                            name="data"
                            onChange={handleChange}
                            // readOnly
                            // value={livroSelecionado && livroSelecionado.data}
                            value={
                                livroSelecionado &&
                                ConvertDataAmericana(livroSelecionado.data)
                            }
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

            <Modal isOpen={modalExcluir}>
                <ModalBody>
                    Confirma a exclusão deste livro:{" "}
                    {livroSelecionado && livroSelecionado.nome} ?
                </ModalBody>

                <ModalFooter>
                    <button
                        className="btm- btn-danger"
                        onClick={() => pedidoDelete()}
                    >
                        {" "}
                        Sim{" "}
                    </button>
                    <button
                        className="btm- btn-secondary"
                        onClick={() => abrirFecharModalExcluir()}
                    >
                        {" "}
                        Não{" "}
                    </button>
                </ModalFooter>
            </Modal>
        </div>
    );
};

export default Home;
