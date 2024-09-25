import "./SegurancaVendas.module.css";

function SegurancaVendas() {
  return (
    <div className="security">
      <h2>Segurança nas vendas!</h2>
      
      <div className="security-content">
        <p>Dinheiro + rápido: Revenda o seu ingresso que não irá usar e receba na hora.</p>
        <p>100% seguro: Sem chance de fraude! Com transações feitas diretamente no site.</p>
        <p>+ chances de ir ao evento: Encontre pessoas que estão revendendo os ingressos.</p>
      </div>
      <button>Vender Ingresso</button>
    </div>
  );
}

export default SegurancaVendas;