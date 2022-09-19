import React, {Component} from 'react';
import {Layout} from './components/Layout';
import './assets/css/untitled.css'
import './assets/bootstrap/css/bootstrap.min.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <nav className="navbar navbar-dark navbar-expand-md sticky-top navbar-shrink py-3" id="mainNav">
                    <div className="container"><a className="navbar-brand d-flex align-items-center" href="/"><span
                        className="bs-icon-sm bs-icon-circle bs-icon-primary shadow d-flex justify-content-center align-items-center me-2 bs-icon"><svg
                        xmlns="http://www.w3.org/2000/svg" wi dth="1em" height="1em" fill="currentColor"
                        viewBox="0 0 16 16"
                        className="bi bi-bezier">
                        <path fill-rule="evenodd"
                              d="M0 10.5A1.5 1.5 0 0 1 1.5 9h1A1.5 1.5 0 0 1 4 10.5v1A1.5 1.5 0 0 1 2.5 13h-1A1.5 1.5 0 0 1 0 11.5v-1zm1.5-.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5h-1zm10.5.5A1.5 1.5 0 0 1 13.5 9h1a1.5 1.5 0 0 1 1.5 1.5v1a1.5 1.5 0 0 1-1.5 1.5h-1a1.5 1.5 0 0 1-1.5-1.5v-1zm1.5-.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5h-1zM6 4.5A1.5 1.5 0 0 1 7.5 3h1A1.5 1.5 0 0 1 10 4.5v1A1.5 1.5 0 0 1 8.5 7h-1A1.5 1.5 0 0 1 6 5.5v-1zM7.5 4a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5h-1z"></path>
                        <path
                            d="M6 4.5H1.866a1 1 0 1 0 0 1h2.668A6.517 6.517 0 0 0 1.814 9H2.5c.123 0 .244.015.358.043a5.517 5.517 0 0 1 3.185-3.185A1.503 1.503 0 0 1 6 5.5v-1zm3.957 1.358A1.5 1.5 0 0 0 10 5.5v-1h4.134a1 1 0 1 1 0 1h-2.668a6.517 6.517 0 0 1 2.72 3.5H13.5c-.123 0-.243.015-.358.043a5.517 5.517 0 0 0-3.185-3.185z"></path>
                    </svg></span><span>Парсинг Циана</span></a>
                        <button data-bs-toggle="collapse" className="navbar-toggler" data-bs-target="#navcol-1"><span
                            className="visually-hidden">Toggle navigation</span><span
                            className="navbar-toggler-icon"></span>
                        </button>
                        <div className="collapse navbar-collapse" id="navcol-1">
                            <ul className="navbar-nav mx-auto">
                                <li className="nav-item"><a className="nav-link active" href="index.html"></a></li>
                                <li className="nav-item"></li>
                            </ul>
                        </div>
                    </div>
                </nav>
                <header className="bg-dark">
                    <div className="container pt-4 pt-xl-5">
                        <div className="row pt-5">
                            <div className="col-md-8 col-xl-6 text-center text-md-start mx-auto">
                                <div className="text-center">
                                    <p className="fw-bold text-success mb-2"></p>
                                    <h1 className="fw-bold"></h1>
                                </div>
                            </div>
                            <div className="col-12 col-lg-10 mx-auto">
                                <div className="position-relative"
                                     style={{
                                         display: "flex",
                                         flexWrap: "wrap",
                                         justifyContent: 'flex-end'
                                     }}>
                                    <div
                                        style={{
                                            position: "relative",
                                            flex: "0 0 45%",
                                            transform: "translate3d(-15%, 35%, 0)"
                                        }}></div>
                                    <div
                                        style={{
                                            position: "relative",
                                            flex: "0 0 45 %",
                                            transform: "translate3d(-5 %, 20 %, 0)"
                                        }}></div>
                                    <div
                                        style={{
                                            position: "relative",
                                            flex: "0 0 60 %",
                                            transform: "translate3d(0, 0 %, 0)"
                                        }}></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </header>
                <section>
                    <div className="container bg-dark py-5">
                        <div className="py-5 p-lg-5">
                            <div className="row row-cols-1 row-cols-md-2 mx-auto" style={{maxWidth: "900px"}}>
                                <div className="col mb-5">
                                    <div className="card shadow-sm">
                                        <a href="/parsing?region=Bryansk" className="btn btn-primary">Брянск</a>
                                    </div>
                                </div>
                                <div className="col mb-5">
                                    <div className="card shadow-sm">
                                        <a href="/parsing?region=Moscow" className="btn btn-danger">Москва</a>

                                    </div>
                                </div>
                                <div className="col mb-4">
                                    <div className="card shadow-sm"></div>
                                </div>
                                <div className="w-100"></div>
                                <div className="col-lg-6"></div>
                                <div className="col"></div>
                            </div>
                        </div>
                    </div>
                </section>
                <section>
                    <div className="container py-5">
                        <div className="mx-auto" style={{maxWidth: "900px"}}>
                            <div className="row row-cols-1 row-cols-md-2 d-flex justify-content-center">
                                <div className="col mb-4">
                                    <div className="card bg-primary-light"></div>
                                </div>
                                <div className="col mb-4">
                                    <div className="card bg-secondary-light"></div>
                                </div>
                                <div className="col mb-4">
                                    <div className="card bg-info-light"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <footer className="bg-dark"></footer>
            </Layout>
        );
    }
}
