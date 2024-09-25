import "./BarraPesquisa.module.css";

function BarraPesquisa() {
  return (
    <div className="search-bar">
      <input type="text" placeholder="Digite o nome do evento..." />
      <button>Pesquisar</button>
    </div>
  );
}

export default BarraPesquisa;