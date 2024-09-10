import { BrowserRouter, Route, Routes } from "react-router-dom";
import Menu from "./components/Menu";
import Rodape from "./components/Rodape";
import PaginaPadrao from "./components/PaginaPadrao";

import Inicio from './pages/Inicio';
import Eventos from "./pages/Eventos"
import ComoFunciona from "./pages/ComoFunciona"
import Sobre from './pages/Sobre';
import Login from "./pages/Login"
import NaoEncontrada from "./pages/NaoEncontrada"

function AppRoutes() {
  return (
    <BrowserRouter>
      <Menu />

      <Routes>
        <Route path="/" element={<PaginaPadrao />}>
          <Route index element={<Inicio />} />

          <Route path="eventos" element={<Eventos />}/>
          <Route path="como-funciona" element={<ComoFunciona />}/>
          <Route path="sobre" element={<Sobre />}/>
          <Route path="login" element={<Login />}/>
        </Route>
        
        <Route path="*" element={<NaoEncontrada />}/>
      </Routes>

      <Rodape />
    </BrowserRouter>
  );
}

export default AppRoutes;