/* App ADW300 - Vue 3 + d3. Frontend (dashboard) com gráficos e diagrama 100% d3. */
const { createApp } = Vue;
const PI = Math.PI;

/* ---------------- helpers ---------------- */
function fmtNum(v){ if(v==null||v==="")return "—"; v=+v; if(!isFinite(v))return "—";
  const a=Math.abs(v); return a>=1000?v.toFixed(0):a>=100?v.toFixed(0):a>=10?v.toFixed(1):v.toFixed(2); }

/* ---- diagrama de pipeline (SVG nativo via d3, sem imagem) ---- */
function drawPipeline(el){
  if(!el || el.__done) return; el.__done = true; el.innerHTML="";
  const W=1000,H=430;
  const svg=d3.select(el).append("svg").attr("viewBox","0 0 "+W+" "+H).attr("class","diagram");
  const defs=svg.append("defs");
  [["arrG","#2fa36b"],["arrS","#8894ab"],["arrB","#2f6fed"]].forEach(([id,c])=>{
    defs.append("marker").attr("id",id).attr("viewBox","0 0 10 10").attr("refX",9).attr("refY",5)
      .attr("markerWidth",7).attr("markerHeight",7).attr("orient","auto-start-reverse")
      .append("path").attr("d","M0,0L10,5L0,10z").attr("fill",c);
  });
  function box(x,y,w,h,title,sub,fill,tcol){
    const g=svg.append("g");
    g.append("rect").attr("x",x).attr("y",y).attr("width",w).attr("height",h).attr("rx",16)
      .attr("fill",fill).attr("filter","url(#sh)");
    g.append("text").attr("x",x+w/2).attr("y",y+h/2-(sub?8:0)).attr("text-anchor","middle")
      .attr("fill",tcol||"#fff").attr("font-size",19).attr("font-weight",700).text(title);
    if(sub) g.append("text").attr("x",x+w/2).attr("y",y+h/2+15).attr("text-anchor","middle")
      .attr("fill",tcol?tcol:"#d6e2fb").attr("font-size",13).attr("font-weight",600).text(sub);
    return g;
  }
  defs.append("filter").attr("id","sh").attr("x","-20%").attr("y","-20%").attr("width","140%").attr("height","160%")
    .append("feDropShadow").attr("dx",0).attr("dy",4).attr("stdDeviation",6).attr("flood-color","#9aa7bc").attr("flood-opacity",.35);
  function line(x1,y1,x2,y2,color,marker,dash){
    svg.append("path").attr("d","M"+x1+","+y1+"L"+x2+","+y2).attr("stroke",color).attr("stroke-width",3)
      .attr("fill","none").attr("marker-end","url(#"+marker+")").attr("stroke-dasharray",dash||null)
      .attr("marker-start", dash?("url(#"+marker+")"):null);
  }
  function label(x,y,txt,color,size,anchor,weight){
    svg.append("text").attr("x",x).attr("y",y).attr("text-anchor",anchor||"middle")
      .attr("fill",color).attr("font-size",size||12.5).attr("font-weight",weight||700).text(txt);
  }
  // seção labels
  label(60,34,"PRODUÇÃO (permanente)","#2fa36b",13,"start");
  label(410,278,"SETUP / TESTE (removido depois)","#2f6fed",13,"start");
  // caixas
  box(50,48,230,96,"MEDIDOR","ADW300 4G","#7a5cd0");
  box(720,66,230,118,"AWS","IoT Core","#16213a");
  box(60,300,185,96,"Conversor","USB-RS485","#64708a");
  box(405,300,255,96,"LAPTOP","(web-app Docker)","#2f6fed");
  // produção ADW300 -> AWS
  line(280,96,720,104,"#2fa36b","arrG");
  label(498,66,"rede 4G · MQTT · TLS mútuo (certificado X.509)","#2fa36b",13.5);
  label(498,116,"o medidor publica sozinho, sem PC","#8894ab",12,"middle",600);
  // ADW300 -> USB (setup, captura)
  line(150,144,150,300,"#8894ab","arrS");
  label(170,200,"setup de parâmetros","#64708a",12.5,"start");
  label(170,218,"(certificados · endpoint · QoS ·","#8894ab",11.5,"start",600);
  label(170,234,"intervalo) + captura em tempo real","#8894ab",11.5,"start",600);
  // USB <-> laptop
  line(245,348,405,348,"#8894ab","arrS");
  label(325,336,"USB","#64708a",12,"middle");
  // laptop -> AWS (publica e recebe)
  line(655,330,775,190,"#2f6fed","arrB","7 5");
  label(710,250,"publica","#2f6fed",12,"start");
  label(710,266,"e recebe","#2f6fed",12,"start");
}

/* ---- donut d3 (categorias do payload) ---- */
function drawDonut(el, cats){
  if(!el || el.__done) return; el.__done=true; el.innerHTML="";
  const W=260,H=260,r=118,ir=74;
  const svg=d3.select(el).append("svg").attr("viewBox","0 0 "+W+" "+H);
  const g=svg.append("g").attr("transform","translate("+W/2+","+H/2+")");
  const pie=d3.pie().value(d=>d[1]).sort(null);
  const arc=d3.arc().innerRadius(ir).outerRadius(r).cornerRadius(3).padAngle(.014);
  const arcHover=d3.arc().innerRadius(ir).outerRadius(r+8).cornerRadius(3).padAngle(.014);
  const center=g.append("text").attr("text-anchor","middle").attr("dy","-2").attr("font-size",38)
    .attr("font-weight",800).attr("fill","#161f30").text("73");
  const sub=g.append("text").attr("text-anchor","middle").attr("dy","18").attr("font-size",12)
    .attr("fill","#64708a").text("grandezas");
  g.selectAll("path").data(pie(cats)).join("path")
    .attr("d",arc).attr("fill",d=>d.data[2]).attr("stroke","#fff").attr("stroke-width",2)
    .style("cursor","pointer")
    .on("mouseenter",function(ev,d){ d3.select(this).transition().duration(150).attr("d",arcHover);
      center.text(d.data[1]); sub.text(d.data[0].length>22?d.data[0].slice(0,22)+"…":d.data[0]); })
    .on("mouseleave",function(){ d3.select(this).transition().duration(150).attr("d",arc);
      center.text("73"); sub.text("grandezas"); })
    .append("title").text(d=>d.data[0]+": "+d.data[1]);
}

/* ---- gauge d3 (cria uma vez, anima a cada atualização) ---- */
function gauge(el, o){
  const W=170,H=138,R=58,cx=85,cy=90, a0=-135*PI/180, a1=135*PI/180;
  const sc=d3.scaleLinear().domain([o.min,o.max]).range([a0,a1]).clamp(true);
  const ga=d3.arc().innerRadius(R-11).outerRadius(R).cornerRadius(6);
  let svg=d3.select(el).select("svg");
  if(svg.empty()){
    svg=d3.select(el).append("svg").attr("viewBox","0 0 "+W+" "+H);
    const g=svg.append("g").attr("transform","translate("+cx+","+cy+")").attr("class","gg");
    g.append("path").attr("class","track").attr("fill","#eaeef5")
      .attr("d",ga({startAngle:a0,endAngle:a1}));
    // ticks
    const ticks=d3.range(0,11).map(i=>a0+(a1-a0)*i/10);
    g.selectAll(".tk").data(ticks).join("line").attr("class","tk")
      .attr("x1",a=>(R+3)*Math.sin(a)).attr("y1",a=>-(R+3)*Math.cos(a))
      .attr("x2",a=>(R+8)*Math.sin(a)).attr("y2",a=>-(R+8)*Math.cos(a))
      .attr("stroke","#cdd6e4").attr("stroke-width",1.5).attr("stroke-linecap","round");
    g.append("path").attr("class","val").attr("fill",o.color);
    g.append("text").attr("class","num").attr("text-anchor","middle").attr("dy",0)
      .attr("font-size",24).attr("font-weight",800).attr("fill","#161f30").text("—");
    g.append("text").attr("class","unit").attr("text-anchor","middle").attr("dy",20)
      .attr("font-size",11).attr("font-weight",600).attr("fill","#64708a").text(o.unit||"");
    g.append("text").attr("x",-(R+2)*0.72).attr("y",(R+2)*0.72+12).attr("text-anchor","middle")
      .attr("font-size",9).attr("fill","#9aa6ba").text(o.min);
    g.append("text").attr("x",(R+2)*0.72).attr("y",(R+2)*0.72+12).attr("text-anchor","middle")
      .attr("font-size",9).attr("fill","#9aa6ba").text(o.max);
  }
  const g=svg.select(".gg");
  const has=o.value!=null&&o.value!=="";
  const val=g.select(".val").attr("fill",o.color);
  val.transition().duration(700).attrTween("d",function(){
    const prev=this.__e==null?a0:this.__e; const next=has?sc(+o.value):a0; this.__e=next;
    const i=d3.interpolate(prev,next); return t=>ga({startAngle:a0,endAngle:i(t)});
  });
  const num=g.select(".num");
  num.transition().duration(700).tween("t",function(){
    const prev=this.__v==null?o.min:this.__v; const next=has?+o.value:o.min; this.__v=next;
    const i=d3.interpolateNumber(prev,next);
    return t=> this.textContent = has?fmtNum(i(t)):"—";
  });
  g.select(".unit").text(o.unit||"");
}

/* ---- line chart d3 (gradiente + grid + hover) ---- */
function drawLine(el, data, color, id){
  if(!el) return; el.innerHTML=""; const W=620,H=230,m={t:16,r:18,b:26,l:44};
  const svg=d3.select(el).append("svg").attr("viewBox","0 0 "+W+" "+H);
  if(!data||data.length<2){ svg.append("text").attr("x",W/2).attr("y",H/2).attr("text-anchor","middle")
      .attr("fill","#9aa6ba").attr("font-size",13).text("coletando dados..."); return; }
  const gid="grad_"+id;
  const grad=svg.append("defs").append("linearGradient").attr("id",gid).attr("x1",0).attr("x2",0).attr("y1",0).attr("y2",1);
  grad.append("stop").attr("offset","0%").attr("stop-color",color).attr("stop-opacity",.28);
  grad.append("stop").attr("offset","100%").attr("stop-color",color).attr("stop-opacity",0);
  const x=d3.scaleTime().domain(d3.extent(data,d=>d.t)).range([m.l,W-m.r]);
  const ymax=d3.max(data,d=>d.v)||1, ymin=d3.min(data,d=>d.v);
  const y=d3.scaleLinear().domain([Math.max(0,ymin*0.8),ymax*1.15]).nice().range([H-m.b,m.t]);
  const ay=svg.append("g").attr("transform","translate("+m.l+",0)")
    .call(d3.axisLeft(y).ticks(4).tickSize(-(W-m.l-m.r)));
  ay.selectAll(".tick line").attr("stroke","#eef2f8"); ay.select(".domain").remove();
  const ax=svg.append("g").attr("transform","translate(0,"+(H-m.b)+")")
    .call(d3.axisBottom(x).ticks(5).tickSizeOuter(0).tickFormat(d3.timeFormat("%H:%M:%S")));
  ax.select(".domain").attr("stroke","#d5dde9");
  svg.selectAll(".tick text").attr("fill","#8894ab").attr("font-size",10);
  const area=d3.area().x(d=>x(d.t)).y0(H-m.b).y1(d=>y(d.v)).curve(d3.curveMonotoneX);
  const line=d3.line().x(d=>x(d.t)).y(d=>y(d.v)).curve(d3.curveMonotoneX);
  svg.append("path").datum(data).attr("fill","url(#"+gid+")").attr("d",area);
  svg.append("path").datum(data).attr("fill","none").attr("stroke",color).attr("stroke-width",2.6)
    .attr("stroke-linejoin","round").attr("d",line);
  const last=data[data.length-1];
  svg.append("circle").attr("cx",x(last.t)).attr("cy",y(last.v)).attr("r",4).attr("fill",color).attr("stroke","#fff").attr("stroke-width",2);
  // hover
  const focus=svg.append("g").style("display","none");
  focus.append("line").attr("y1",m.t).attr("y2",H-m.b).attr("stroke","#c3cde0").attr("stroke-width",1).attr("stroke-dasharray","3 3");
  focus.append("circle").attr("r",4.5).attr("fill",color).attr("stroke","#fff").attr("stroke-width",2);
  const tip=focus.append("g");
  const tbg=tip.append("rect").attr("rx",5).attr("fill","#161f30").attr("height",20).attr("y",-26);
  const ttx=tip.append("text").attr("y",-12).attr("fill","#fff").attr("font-size",11).attr("font-weight",700).attr("text-anchor","middle");
  const bis=d3.bisector(d=>d.t).left;
  svg.append("rect").attr("x",m.l).attr("y",m.t).attr("width",W-m.l-m.r).attr("height",H-m.t-m.b)
    .attr("fill","transparent").style("cursor","crosshair")
    .on("mouseenter",()=>focus.style("display",null)).on("mouseleave",()=>focus.style("display","none"))
    .on("mousemove",function(ev){ const mx=d3.pointer(ev,this)[0]+m.l; const t0=x.invert(mx);
      let i=bis(data,t0); i=Math.max(1,Math.min(data.length-1,i));
      const d=(t0-data[i-1].t>data[i].t-t0)?data[i]:data[i-1];
      const px=x(d.t),py=y(d.v);
      focus.attr("transform",null); focus.select("line").attr("x1",px).attr("x2",px);
      focus.select("circle").attr("cx",px).attr("cy",py);
      const txt=fmtNum(d.v); tip.attr("transform","translate("+px+","+py+")");
      ttx.text(txt); const w=txt.length*7+16; tbg.attr("width",w).attr("x",-w/2);
    });
}

const GAUGES=[
 {id:1,label:"Tensão A",min:0,max:260,unit:"V",color:"#2f6fed"},
 {id:7,label:"Corrente A",min:0,max:100,unit:"A",color:"#12a5a0"},
 {id:13,label:"Potência total",min:0,max:50,unit:"kW",color:"#7a5cd0"},
 {id:25,label:"Fator de pot.",min:0,max:1,unit:"",color:"#2fa36b"},
 {id:26,label:"Frequência",min:55,max:65,unit:"Hz",color:"#f2a63b"},
 {id:40,label:"Corr. de fuga",min:0,max:0.1,unit:"A",color:"#e2574c"},
];
const NAV=[["home","Home","◆"],["monitor","Monitor","▲"],["setup","Setup","⚙"],["nuvem","Nuvem / AWS","☁"],["sobre","Sobre","ⓘ"]];

createApp({
  data(){return{
    view:"home", info:null, snap:null, hist:[], chist:[], gEls:{},
    gauges:GAUGES, nav:NAV, s4g:{}, s4gFields:[],
    form:{addr:"",baud:"9600",pt:"",ct:""},
    readMsg:"",readCfg:null,writeMsg:"",save4gMsg:"",rawMsg:"",diag:null,diagMsg:"",wizMsg:"",
    raw:{addr:"",count:1,write:""},
  }},
  computed:{
    st(){return this.snap?this.snap.status:{};},
    vals(){return this.snap?this.snap.values:{};},
    cloud(){return this.snap&&this.snap.cloud?this.snap.cloud:{values:{},log:[],count:0};},
    names(){return this.info?this.info.names:{};},
    ids(){return this.info?Object.keys(this.info.names).map(Number).sort((a,b)=>a-b):[];},
    rs(){ const s=this.st||{};
      if(!this.snap) return {cls:"mut",label:"conectando…",detail:""};
      if(s.mode==="simulator") return {cls:"mut",label:"Simulador (sem RS485)",detail:"modo de teste — sem hardware"};
      if(s.meter_ok) return {cls:"ok",label:"RS485 conectado",detail:(s.meter_detail||"")+" · recebendo sinal"};
      return {cls:"bad",label:"RS485 sem sinal",detail:s.error||"sem resposta do medidor"};
    },
  },
  methods:{
    async loadInfo(){ this.info=await (await fetch("/api/info")).json();
      this.s4g=Object.assign({},this.info.setup4g); this.s4gFields=this.info.aws_fields;
      this.$nextTick(()=>this.drawHome()); },
    async tick(){ try{
        const s=await (await fetch("/api/snapshot")).json(); this.snap=s;
        const p=s.values[13]; if(p!==undefined){ this.hist.push({t:new Date(),v:+p}); if(this.hist.length>80)this.hist.shift(); }
        const cv=s.cloud&&s.cloud.values?s.cloud.values[13]:undefined;
        if(cv!==undefined){ this.chist.push({t:new Date(),v:+cv}); if(this.chist.length>80)this.chist.shift(); }
        this.$nextTick(()=>this.drawActive());
      }catch(e){} },
    drawActive(){ if(this.view==="monitor"){ this.drawGauges(); drawLine(this.$refs.mline,this.hist,"#2f6fed","m"); }
      else if(this.view==="nuvem"){ drawLine(this.$refs.cline,this.chist,"#12a5a0","c"); }
      else if(this.view==="home"){ this.drawHome(); } },
    drawHome(){ if(this.$refs.pipeline) drawPipeline(this.$refs.pipeline);
      if(this.$refs.donut&&this.info) drawDonut(this.$refs.donut,this.info.categories); },
    drawGauges(){ for(const g of GAUGES){ const el=this.gEls[g.id]; if(el) gauge(el,{value:this.vals[g.id],min:g.min,max:g.max,unit:g.unit,color:g.color}); } },
    go(v){ this.view=v; this.$nextTick(()=>this.drawActive()); },
    nm(id){ return this.names[id]?this.names[id][0]:("id "+id); },
    un(id){ return this.names[id]?this.names[id][1]:""; },
    show(v){ return v===undefined||v===null?"—":v; },
    async togglePublish(){ await fetch("/api/publish?on="+(!this.st.publishing),{method:"POST"}); this.tick(); },
    async runDiag(){ this.diagMsg="Diagnosticando..."; this.diag=null;
      const r=await (await fetch("/api/diag",{method:"POST"})).json();
      this.diagMsg=""; this.diag=r.ok?r.diag:{link:{ok:false,detail:r.error},modbus:{ok:false,detail:""},scan:[],suggestions:[]}; },
    async setupRead(){ this.readMsg="Lendo..."; this.readCfg=null;
      const r=await (await fetch("/api/setup/read",{method:"POST"})).json();
      if(r.ok){ this.readCfg=r.config; this.readMsg="ok"; const c=r.config;
        this.form.addr=c.slave_address; if(c.baud_rate)this.form.baud=String(c.baud_rate); this.form.pt=c.pt; this.form.ct=c.ct; }
      else this.readMsg="err:"+r.error; },
    async setupWrite(){ const b={}; if(this.form.addr!=="")b.slave_address=+this.form.addr; b.baud_rate=+this.form.baud;
      if(this.form.pt!=="")b.pt=+this.form.pt; if(this.form.ct!=="")b.ct=+this.form.ct; this.writeMsg="Gravando...";
      const r=await (await fetch("/api/setup/write",{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify(b)})).json();
      this.writeMsg=r.ok?("ok:"+r.applied.join("; ")):("err:"+r.error); },
    async save4g(){ const r=await (await fetch("/api/setup/4g",{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify(this.s4g)})).json();
      this.s4g=r.config; this.save4gMsg="resumo:"+this.resumo(); },
    resumo(){ return Object.keys(this.s4g).map(k=>k.padEnd(16)+": "+this.s4g[k]).join("\n"); },
    copy4g(){ navigator.clipboard.writeText(this.resumo()); this.save4gMsg="copied"; },
    wizText(){ const g=this.s4g||{};
      return [
       "=== ADW300 -> AWS IoT Core | valores para o software ACREL ===","",
       "[Porta serial]  port=COMx   Baud=9600   Data bits=8   stop bits=1   parity=N","",
       "[environment 1 / GPRS-NB]",
       "  IP or domain  : Dominio (Domain Name)  <- NAO usar IP",
       "  port1         : 8883        (MQTT sobre TLS - AWS exige 8883, NAO 1883)",
       "  serial_number : "+(g.device_number||"<numero de 14 digitos do medidor>"),
       "  Upload interval: "+(g.upload_interval||5)+"   (1 a 15 min)","",
       "[environment 1 / Domain]",
       "  domain1       : "+(g.domain||"<endpoint-ats>.iot.<regiao>.amazonaws.com"),"",
       "[MQTT]",
       "  MQTT username : (deixar vazio)",
       "  MQTT password : (deixar vazio)   <- no AWS a auth e por certificado",
       "  MQTT theme_2  : "+(g.topic_data||"<topico de dados>")+"   (topico de upload)",
       "  ClientID      : "+(g.client_id||"<numero de 14 digitos / thing>"),
       "  MQTT QoS      : 1","",
       "[SSL/TLS]  importar os 3 arquivos .bin (baixados na secao 4):",
       "  1) AmazonRootCA1.bin   2) device-certificate.bin   3) private-key.bin","",
       "Depois: SET em cada aba -> religar o medidor -> remover USB. Publica pela 4G.",
      ].join("\n"); },
    copyWiz(){ navigator.clipboard.writeText(this.wizText()); this.wizMsg="copied"; setTimeout(()=>this.wizMsg="",2500); },
    async rawExec(){ const b={addr:+this.raw.addr,count:+this.raw.count||1}; if(this.raw.write!=="")b.write=+this.raw.write;
      const r=await (await fetch("/api/setup/raw",{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify(b)})).json();
      this.rawMsg=r.ok?("ok:"+JSON.stringify(r.result)):("err:"+r.error); },
  },
  mounted(){ this.loadInfo(); this.tick(); setInterval(this.tick,2000); },
  template: `
<div class="app">
 <nav class="side">
  <div class="brand"><span class="logo"><i></i><i></i></span><div><b>ADW300</b><span>Prana IoT</span></div></div>
  <div class="nav">
   <a v-for="n in nav" :key="n[0]" :class="{active:view===n[0]}" @click="go(n[0])"><span class="ic">{{n[2]}}</span>{{n[1]}}</a>
  </div>
  <div class="rsind" :class="rs.cls" @click="go('setup')" title="Status do link RS485 — clique para diagnosticar">
   <span class="rs-ico"><svg viewBox="0 0 24 24"><rect x="2" y="15" width="4" height="6" rx="1"/><rect x="10" y="9" width="4" height="12" rx="1"/><rect x="18" y="3" width="4" height="18" rx="1"/></svg></span>
   <div class="rs-tx"><b>{{rs.label}}</b><span>{{rs.detail}}</span></div>
  </div>
  <div class="foot">Ferramenta local de <b>setup</b> e <b>teste</b>. Depois do setup, o USB e o PC são removidos — o medidor segue enviando pela 4G.</div>
 </nav>
 <main class="main">

  <!-- HOME -->
  <section v-show="view==='home'">
   <div class="hero">
    <div class="hero-txt">
     <div class="logo"><i style="background:#4d8bf0"></i><i style="background:#12a5a0"></i></div>
     <h1>ADW300 4G &rarr; AWS IoT Core</h1>
     <p>Configure o medidor <b>Acrel ADW300 4G</b> para enviar os dados de energia <b>direto</b> para o AWS IoT Core pela rede 4G (TLS mútuo, certificado X.509), e <b>teste/visualize</b> todo o fluxo. Depois do setup, o cabo USB e o PC são removidos.</p>
     <div class="chips"><span class="chip">USB-RS485 · Modbus-RTU</span><span class="chip">MQTT · TLS mútuo</span><span class="chip">73 grandezas</span><span class="chip">Publica e recebe</span></div>
    </div>
   </div>

   <div class="panel">
    <div class="phead"><h2>Como funciona o pipeline</h2><span class="tag">diagrama d3</span></div>
    <p class="ph">Em produção o medidor publica sozinho pela 4G. O laptop (este app) é usado só no setup e no teste.</p>
    <div class="chart diagram-wrap" ref="pipeline"></div>
   </div>

   <div class="panel">
    <h2>Passo a passo</h2>
    <div class="steps">
     <div class="step" v-for="s in (info?info.pipeline:[])" :key="s[0]"><div class="n">{{s[0]}}</div><div><h3>{{s[1]}}</h3><p>{{s[2]}}</p></div></div>
    </div>
   </div>

   <div class="grid2 wide">
    <div class="panel">
     <div class="phead"><h2>As 73 grandezas do payload</h2><span class="tag">donut d3</span></div>
     <p class="ph">Passe o mouse para ver cada categoria. Distribuição dos ids 0–72:</p>
     <div class="donut-wrap">
      <div class="chart donut" ref="donut"></div>
      <div class="legend">
       <div class="li" v-for="c in (info?info.categories:[])" :key="c[0]"><span class="sw" :style="{background:c[2]}"></span><span class="lt">{{c[0]}}</span><b>{{c[1]}}</b></div>
      </div>
     </div>
    </div>
    <div class="panel">
     <h2>Configuração do medidor</h2>
     <p class="ph">Valores digitados no software ACREL (Domain 1, MQTT, SSL/TLS).</p>
     <div class="kv" v-if="info">
      <span class="k">Endpoint</span><span class="val mono">{{info.endpoint}}</span>
      <span class="k">Porta</span><span class="val mono">{{info.port}} · TLS</span>
      <span class="k">Tópico</span><span class="val mono">{{info.adw300.topic}}</span>
      <span class="k">ClientID</span><span class="val mono">{{info.adw300.client_id}}</span>
      <span class="k">Device ID</span><span class="val mono">{{info.device_id}}</span>
      <span class="k">SSL/TLS</span><span class="val mono">RootCA + device + key (.bin)</span>
     </div>
     <div class="callout teal"><b>Identidades:</b> medidor = <b>ADW300-Certs</b>; app = <b>Web-Certs</b> (clientID {{info?info.web.client_id:''}}). ClientIDs diferentes = os dois no AWS em paralelo.</div>
    </div>
   </div>

   <div class="panel">
    <h2>Mapa de registradores Modbus (RS485, função 03H)</h2>
    <div class="tbl-wrap"><table><thead><tr><th>Grandeza</th><th>Modbus</th><th>Palavras</th><th>Escala</th><th>Unid.</th></tr></thead>
     <tbody><tr v-for="r in (info?info.register_table:[])" :key="r[1]"><td>{{r[0]}}</td><td><code>{{r[1]}}</code></td><td class="ctr">{{r[2]}}</td><td class="ctr">{{r[3]}}</td><td class="u">{{r[4]}}</td></tr></tbody></table></div>
   </div>
  </section>

  <!-- MONITOR -->
  <section v-show="view==='monitor'">
   <div class="page-h"><div><h1>Monitor / Teste</h1><p>Lê o medidor por RS485 (ou simula) com medidores d3 ao vivo. Pode publicar no AWS para validar o pipeline. Não fica no caminho em produção.</p></div></div>
   <div class="cards">
    <div class="card tile"><div class="lab">Medidor</div><div class="val"><span class="pill" :class="st.meter_ok?'ok':'bad'"><span class="dot"></span>{{st.meter_ok?'OK':'SEM LEITURA'}}</span></div><div class="sub">{{st.mode==='simulator'?'SIMULADOR':'MEDIDOR'}} · {{st.meter_detail||'—'}}</div></div>
    <div class="card tile"><div class="lab">AWS IoT Core</div><div class="val"><span class="pill" :class="st.aws_connected?'ok':'bad'"><span class="dot"></span>{{st.aws_connected?'CONECTADO':'OFFLINE'}}</span></div><div class="sub">{{st.last_publish?('envio '+st.last_publish.substr(11,8)+'Z'):'aguardando'}}</div></div>
    <div class="card tile"><div class="lab">Publicação</div><div class="val"><span class="pill" :class="st.publishing?'ok':'mut'"><span class="dot"></span>{{st.publishing?'LIGADA':'DESLIGADA'}}</span></div><div class="sub">{{st.read_count}} leituras · {{st.publish_count}} envios</div></div>
    <div class="card tile"><div class="lab">Envio ao AWS {{st.mode==='simulator'?'(simulado)':''}}</div>
     <div class="switchrow" @click="togglePublish"><div class="switch" :class="{on:st.publishing}"><span></span></div><b>{{st.publishing?'ATIVADO':'DESATIVADO'}}</b></div>
     <div class="sub">{{st.publishing?'enviando ao IoT Core':'parado — nada é enviado'}}</div></div>
   </div>
   <div class="gauges">
    <div class="gauge" v-for="g in gauges" :key="g.id"><div class="glab">{{g.label}}</div><div class="chart" :ref="el=>{ if(el) gEls[g.id]=el }"></div></div>
   </div>
   <div class="grid2 wide">
    <div class="panel"><div class="phead"><h2>Potência total ao vivo</h2><span class="tag">kW</span></div><div class="chart" ref="mline"></div></div>
    <div class="panel"><h2>Registro de eventos</h2><pre class="log">{{snap?snap.logs.join('\\n'):''}}</pre></div>
   </div>
   <div class="panel"><h2>Todas as grandezas</h2>
    <div class="tbl-wrap"><table><thead><tr><th>ID</th><th>Grandeza</th><th class="r">Valor</th><th>Un.</th></tr></thead>
     <tbody><tr v-for="id in ids" :key="id"><td>{{id}}</td><td>{{nm(id)}}</td><td class="v">{{show(vals[id])}}</td><td class="u">{{un(id)}}</td></tr></tbody></table></div>
   </div>
  </section>

  <!-- SETUP -->
  <section v-show="view==='setup'">
   <div class="page-h"><div><h1>Setup do ADW300</h1><p>Acesse o medidor pelo USB-RS485 para confirmar a ligação, ajustar a comunicação e montar os parâmetros 4G/MQTT.</p></div></div>
   <div class="panel"><h2>1. Conexão RS485 com o medidor</h2>
    <div class="rsbadge" :class="rs.cls">
     <span class="rs-ico"><svg viewBox="0 0 24 24"><rect x="2" y="15" width="4" height="6" rx="1"/><rect x="10" y="9" width="4" height="12" rx="1"/><rect x="18" y="3" width="4" height="18" rx="1"/></svg></span>
     <div class="rs-tx"><b>{{rs.label}}</b><span>{{rs.detail}}</span></div>
    </div>
    <p class="ph">Requer modo <code>meter</code> no config.yml e o medidor + conversor USB-RS485 ligados.</p>
    <div class="btnrow"><button @click="runDiag">Diagnosticar conexão</button><button class="ghost" @click="setupRead">Ler configuração</button>
     <span class="hint" v-if="diagMsg">{{diagMsg}}</span></div>
    <div class="msg" :class="readMsg==='ok'?'ok':(readMsg.startsWith('err')?'bad':'')" v-if="readMsg">{{readMsg==='ok'?'✓ Medidor respondeu pelo RS485.':(readMsg.startsWith('err')?('⚠ '+readMsg.slice(4)):readMsg)}}</div>
    <div class="tbl-wrap" v-if="readCfg" style="margin-top:10px;max-width:420px"><table>
     <tr><th>Parâmetro</th><th>Valor</th></tr>
     <tr><td>Endereço Modbus</td><td class="v">{{readCfg.slave_address}}</td></tr><tr><td>Velocidade</td><td class="v">{{readCfg.baud_rate||readCfg.baud_code}} baud</td></tr>
     <tr><td>Paridade / stop</td><td class="v">{{readCfg.parity}} / {{readCfg.stopbits}}</td></tr><tr><td>PT</td><td class="v">{{readCfg.pt}}</td></tr><tr><td>CT</td><td class="v">{{readCfg.ct}}</td></tr></table></div>
    <div v-if="diag" class="diagbox">
     <div class="diagrow" v-if="diag.mode!=='simulator'"><span class="pill" :class="diag.link.ok?'ok':'bad'"><span class="dot"></span>{{diag.link.ok?'Ponte / COM OK':'Ponte / COM falhou'}}</span><span class="dd">{{diag.link.detail}}</span></div>
     <div class="diagrow" v-if="diag.mode!=='simulator'"><span class="pill" :class="diag.modbus.ok?'ok':'bad'"><span class="dot"></span>{{diag.modbus.ok?'Medidor responde':'Medidor sem resposta'}}</span><span class="dd">{{diag.modbus.detail}}</span></div>
     <div class="dd" v-if="diag.scan&&diag.scan.length"><b>Endereços que responderam:</b> {{diag.scan.join(', ')}}</div>
     <div class="dd muted" v-if="diag.note">{{diag.note}}</div>
     <div v-if="diag.suggestions&&diag.suggestions.length" class="suglist"><b>O que fazer:</b><ul class="bl"><li v-for="(s,i) in diag.suggestions" :key="i">{{s}}</li></ul></div>
    </div>
    <details style="margin-top:14px"><summary>Checklist de debug — "conectado mas sem sinal"</summary>
     <ul class="bl" style="margin-top:8px">
      <li><b>Polaridade A/B:</b> borne 21 → RS485+ (A/D+); borne 22 → RS485− (B/D−). Par trocado é a causa nº 1.</li>
      <li><b>Velocidade:</b> padrão 9600 8N1; alguns ADW300 vêm em 1200. Ajuste <code>baud_rate</code> no config.yml e reinicie.</li>
      <li><b>Endereço Modbus:</b> padrão 1 (1–247). O botão "Diagnosticar" varre 1–16.</li>
      <li><b>Alimentação:</b> medidor energizado (85–265 V).</li>
      <li><b>Porta COM / driver:</b> veja a COM no Gerenciador de Dispositivos; instale o driver <b>CH343SER</b> se não aparecer.</li>
      <li><b>Ponte serial:</b> a janela "ADW300 Ponte Serial" deve estar aberta e ter aberto a COM.</li>
      <li><b>Terminação:</b> em cabo longo, 120 Ω nas duas pontas.</li>
     </ul>
    </details>
   </div>
   <div class="panel"><h2>2. Comunicação do medidor (gravável)</h2><p class="ph">Registradores Modbus verificados. Pode ler e gravar.</p>
    <div class="frm" style="max-width:520px">
     <label>Endereço Modbus (1-247)</label><input type="number" v-model="form.addr" placeholder="1">
     <label>Velocidade (baud)</label><select v-model="form.baud"><option>1200</option><option>2400</option><option>4800</option><option>9600</option></select>
     <label>PT (rel. de tensão)</label><input type="number" v-model="form.pt" placeholder="1">
     <label>CT (rel. de corrente)</label><input type="number" v-model="form.ct" placeholder="1">
    </div>
    <div class="btnrow" style="margin-top:12px"><button @click="setupWrite">Gravar no medidor</button><span class="hint">grava os campos preenchidos</span></div>
    <div class="msg" :class="writeMsg.startsWith('ok')?'ok':(writeMsg.startsWith('err')?'bad':'')" v-if="writeMsg">{{writeMsg.startsWith('ok')?('✓ Gravado: '+writeMsg.slice(3)):(writeMsg.startsWith('err')?('⚠ '+writeMsg.slice(4)):writeMsg)}}</div>
   </div>
   <div class="panel"><h2>3. Envio direto 4G &rarr; AWS</h2><p class="ph">Valores para digitar no software ACREL (Domain 1 e MQTT). Pré-preenchido para o AWS deste projeto.</p>
    <div class="frm" style="max-width:640px">
     <template v-for="f in s4gFields" :key="f[0]"><label>{{f[1]}}</label><div><input v-model="s4g[f[0]]"><div class="hint">{{f[2]}}</div></div></template>
    </div>
    <div class="btnrow" style="margin-top:12px"><button @click="save4g">Salvar e gerar resumo</button><button class="ghost" @click="copy4g">Copiar resumo</button></div>
    <pre v-if="save4gMsg==='copied'" style="margin-top:12px">resumo copiado</pre>
    <pre v-else-if="save4gMsg.startsWith('resumo:')" style="margin-top:12px">{{save4gMsg.slice(7)}}</pre>
    <h2 style="margin-top:20px">4. Certificados SSL/TLS</h2><p class="ph">Importe estes 3 arquivos (.bin) na tela SSL/TLS do software ACREL:</p>
    <div class="btnrow">
     <a href="/api/setup/cert/rootca" download><button class="ghost">1) Amazon Root CA (.bin)</button></a>
     <a href="/api/setup/cert/cert" download><button class="ghost">2) Certificado do dispositivo (.bin)</button></a>
     <a href="/api/setup/cert/key" download><button class="ghost">3) Chave privada (.bin)</button></a>
    </div>

    <div class="certflow">
     <h3>Como a placa ADW300 recebe estes certificados <span class="tagre">engenharia reversa</span></h3>
     <p class="cf-lead">Descompilamos o software de ajuste da Acrel (<span class="mono">ADW300调试软件_V1.49.exe</span>, .NET/WinForms) com o <span class="mono">ilspycmd</span>. O que ele faz pela porta USB-RS485 divide-se em <b>duas coisas diferentes</b>:</p>

     <div class="cf-grid">
      <div class="cf-col ok">
       <div class="cf-h"><span class="dot g"></span>1 · Parâmetros de texto — vão por Modbus (comprovado no código)</div>
       <p>Endpoint, porta, tópico, ClientID, QoS e intervalo são gravados por <b>Modbus-RTU função 10H</b> (escrever múltiplos registradores), em blocos de registradores, strings <b>ASCII</b> preenchidas com <span class="mono">0x00</span> e CRC16 no fim:</p>
       <ul>
        <li><b>Bloco Rede</b> base <span class="mono">0x6000</span>: Domain/endpoint (<span class="mono">0x6016</span>), porta 8883 (<span class="mono">0x6010</span>), intervalo (<span class="mono">0x6001</span>).</li>
        <li><b>Bloco MQTT</b> base <span class="mono">0x7000</span>: tópico de dados (<span class="mono">0x705A</span>), ClientID (<span class="mono">0x7078</span>), QoS (<span class="mono">0x7096</span>). <i>username/password ficam vazios</i> — no AWS a autenticação é por certificado, não por senha.</li>
       </ul>
       <p class="cf-proof">Trecho real de <span class="mono">mqtt_pro.cs</span>: monta um frame <span class="mono">[addr][0x10][0x70 0x00][0x00 0x5A][180]…</span> = escreve <b>90 registradores (180 bytes)</b> a partir de <span class="mono">0x7000</span>, com três campos ASCII de 60 bytes. É isso que o nosso app já automatiza na seção 3.</p>
      </div>

      <div class="cf-col warn">
       <div class="cf-h"><span class="dot y"></span>2 · Os certificados NÃO passam por esse caminho</div>
       <p>Procuramos em <b>todo</b> o código descompilado por <span class="mono">证书 / 密钥 / SSL / TLS / cert / .pem / .der / OpenFileDialog / ReadAllBytes</span> → <b>zero ocorrências</b>.</p>
       <p>Ou seja: a versão <b>V1.49 que descompilamos não tem</b> a tela "SSL/TLS". Essa tela pertence a <b>outra versão, mais nova</b> — a <b>ADW300 configuration software EN T1.2</b>.</p>
       <p><b>Já descompilamos a T1.2 também</b> (aba SSL/TLS com <span class="mono">import Certificate 1/2/3</span>) e o mecanismo está <b>decodificado</b> — ver passo 4 abaixo e <span class="mono">CERTIFICATE-UPLOAD-T1.2.md</span>.</p>
      </div>
     </div>

     <div class="cf-mech">
      <div class="cf-h"><span class="dot b"></span>3 · Como o import realmente acontece (protocolo "ZSDR", decodificado na T1.2)</div>
      <ol>
       <li>Os 3 arquivos são renomeados para <span class="mono">.bin</span> — são apenas os <b>bytes crus</b> do PEM / da chave (o medidor não lê a extensão, lê o conteúdo binário).</li>
       <li>Cada botão (<span class="mono">import Certificate 1/2/3</span>) envia o arquivo pela <b>mesma porta RS485</b> por um <b>canal serial proprietário</b> — <u>não</u> é Modbus. O frame é <span class="mono">5A 53 44 52</span> (ASCII <b>“ZSDR”</b>) + <b>índice</b> (1/2/3) + <b>tamanho</b> (16 bits) + <b>bytes do .bin</b> + <b>CRC16</b>; a placa responde <span class="mono">ZSDRACK</span> em caso de sucesso. Por isso os certificados nunca apareceram no mapa Modbus: eles vão por essa via dedicada.</li>
       <li>O módulo grava os 3 arquivos em <b>memória não-volátil</b> e passa a usá-los no <b>handshake TLS mútuo</b> com o AWS IoT Core:
        <ul>
         <li><b>Amazon Root CA</b> → a placa valida que está mesmo falando com o servidor da AWS.</li>
         <li><b>Certificado do dispositivo + Chave privada</b> → a placa <b>prova a própria identidade</b> para a AWS (a chave privada nunca sai do medidor).</li>
        </ul>
       </li>
       <li>Feito isso, o USB e o PC são removidos: a placa publica sozinha pela <b>4G</b>, direto no AWS IoT Core, sem gateway e sem Wi-Fi.</li>
      </ol>
      <p class="cf-foot"><b>Resumindo:</b> o nosso app já grava os parâmetros de texto por Modbus (seção 3) e <b>gera os 3 <span class="mono">.bin</span> prontos</b> (botões acima). Com a engenharia reversa da T1.2, o canal de certificados (<b>ZSDR</b>) também está <b>decodificado e reprodutível</b> — ou seja, dá para automatizar o upload dos 3 certificados no próprio app, pela mesma ponte RS485. Hoje o passo é feito na software ACREL T1.2 (passo 4).</p>
     </div>
    </div>

    <div class="wizard">
     <div class="wiz-head">
      <h3>Passo a passo — conectar a placa ao AWS pelo software ACREL</h3>
      <p>Você já tem acesso ao ADW300 pela software da Acrel. Siga na ordem; as imagens são <b>recortes reais das telas</b> (guia oficial Acrel) com o que digitar e onde clicar. Regra geral de cada aba: <b>primeiro READ, depois SET</b>.</p>
      <div class="btnrow"><button @click="copyWiz">📋 Copiar valores para o Bloco de Notas</button><span v-if="wizMsg==='copied'" class="wiz-ok">copiado ✓</span></div>
     </div>

     <div class="wstep">
      <div class="wn">0</div>
      <div class="wbody">
       <h4>Abrir a porta serial (USB-RS485)</h4>
       <p>Ligue o conversor USB-RS485 ao ADW300 (borne <b>21 = RS485+/A</b>, <b>22 = RS485-/B</b>). No software clique em <b>SET</b> (canto superior esquerdo) para abrir a janela da porta e preencha:</p>
       <img class="shot" src="/static/screens/serial-port.png?v=__V__" alt="Janela de porta serial do software ACREL">
       <table class="wkv"><tr><td>port</td><td><b>COMx</b> (a porta do seu conversor — veja no Gerenciador de Dispositivos)</td></tr>
        <tr><td>Baud</td><td><b>9600</b></td></tr><tr><td>Data bits</td><td>8</td></tr><tr><td>stop bits</td><td>1</td></tr><tr><td>parity</td><td>N</td></tr></table>
       <p>Clique <b>confirm</b>. Depois clique <b>“Broadcast read”</b> até aparecer <i>“Read success”</i> — isso confirma que o software está falando com o medidor.</p>
      </div>
     </div>

     <div class="wstep">
      <div class="wn">1</div>
      <div class="wbody">
       <h4>Aba “environment 1” → IP / porta / intervalo</h4>
       <p>Abra a aba <b>environment 1</b>. Clique <b>READ</b> primeiro. Na faixa <b>GPRS/NB</b>:</p>
       <img class="shot" src="/static/screens/env1-gprs.png?v=__V__" alt="GPRS/NB do software ACREL">
       <table class="wkv">
        <tr><td>port1</td><td><b>8883</b> <span class="warn-i">⚠ a tela mostra 1883, mas o AWS exige <b>8883</b> (MQTT sobre TLS)</span></td></tr>
        <tr><td>serial_number</td><td>número de <b>14 dígitos</b> do medidor: <span class="mono">{{s4g.device_number||'—'}}</span></td></tr>
        <tr><td>Upload interval</td><td><b>{{s4g.upload_interval||5}}</b> (1 a 15 min)</td></tr>
       </table>
       <p>Clique <b>SET</b> para gravar.</p>
      </div>
     </div>

     <div class="wstep">
      <div class="wn">2</div>
      <div class="wbody">
       <h4>Aba “environment 1” → Domínio (endpoint AWS)</h4>
       <p>Na parte de baixo da mesma aba, no seletor <b>“IP or domain”</b> escolha <b>域名 / Domain Name</b> (domínio, <u>não</u> IP). Clique <b>READ</b>, preencha e depois <b>SET</b>:</p>
       <img class="shot" src="/static/screens/env1-domain.png?v=__V__" alt="Configuração de domínio do software ACREL">
       <table class="wkv"><tr><td>domain1</td><td>endpoint do AWS IoT Core:<br><span class="mono">{{s4g.domain||'xxxxx-ats.iot.us-east-1.amazonaws.com'}}</span></td></tr></table>
       <p class="hintx">Esse endpoint é o mesmo da aba Home/Nuvem deste app (AWS IoT → Settings → Device data endpoint).</p>
      </div>
     </div>

     <div class="wstep">
      <div class="wn">3</div>
      <div class="wbody">
       <h4>Aba “MQTT” → tópico, ClientID e QoS</h4>
       <p>Abra a aba <b>MQTT</b>, clique <b>READ</b> e preencha:</p>
       <img class="shot" src="/static/screens/mqtt-fields.png?v=__V__" alt="Aba MQTT do software ACREL">
       <table class="wkv">
        <tr><td>MQTT username</td><td><i>(deixar vazio)</i></td></tr>
        <tr><td>MQTT password</td><td><i>(deixar vazio)</i> — no AWS a autenticação é por <b>certificado</b>, não por senha</td></tr>
        <tr><td>MQTT theme_2</td><td>tópico de upload dos dados: <span class="mono">{{s4g.topic_data||'test/'}}</span></td></tr>
        <tr><td>ClientID</td><td><span class="mono">{{s4g.client_id||'—'}}</span> (nome do thing / 14 dígitos)</td></tr>
        <tr><td>MQTT QoS</td><td><b>1</b></td></tr>
       </table>
       <p>Clique <b>SET</b>. <span class="hintx">theme_1 é o tópico de comando (download); o importante para os dados é o <b>theme_2</b>.</span></p>
      </div>
     </div>

     <div class="wstep">
      <div class="wn">4</div>
      <div class="wbody">
       <h4>Aba “SSL/TLS” → importar os 3 certificados (.bin)</h4>
       <p>Use a versão <b>ADW300 configuration software EN T1.2</b> (a V1.49 não tem esta aba). Abra a aba <b>SSL/TLS</b> e clique em cada botão para selecionar o <b>.bin</b> correspondente, gerado na <b>seção 4</b> acima:</p>
       <img class="shot" src="/static/screens/ssl-import.png?v=__V__" alt="Aba SSL/TLS do software ACREL T1.2 com import Certificate 1/2/3">
       <table class="wkv">
        <tr><td>import Certificate 1</td><td><span class="mono">AmazonRootCA1.bin</span> — Amazon Root CA</td></tr>
        <tr><td>import Certificate 2</td><td><span class="mono">device-certificate.bin</span> — certificado do dispositivo</td></tr>
        <tr><td>import Certificate 3</td><td><span class="mono">private-key.bin</span> — chave privada</td></tr>
       </table>
       <p>Cada import mostra <i>“import certificateN success!”</i> quando a placa confirma. A chave privada é gravada no medidor e nunca mais sai de lá.</p>
       <div class="callout teal" style="margin-top:8px"><b>Engenharia reversa (T1.2):</b> o envio <u>não</u> é Modbus — é um canal serial próprio <b>“ZSDR”</b>: cabeçalho <span class="mono">5A 53 44 52</span> + índice (1/2/3) + tamanho (16 bits) + bytes do <span class="mono">.bin</span> + CRC16; a placa responde <span class="mono">ZSDRACK</span>. Decodificado em <span class="mono">CERTIFICATE-UPLOAD-T1.2.md</span> — dá para automatizar no próprio app.</div>
      </div>
     </div>

     <div class="wstep">
      <div class="wn">5</div>
      <div class="wbody">
       <h4>Finalizar e verificar</h4>
       <p><b>Religue o medidor</b> (desliga/liga a alimentação) para ele aplicar a config e abrir o link 4G. Depois <b>remova o USB-RS485 e o PC</b> — não são mais necessários.</p>
       <p>Confirme a chegada dos dados no <b>AWS IoT Core → MQTT test client</b>, assinando o tópico <span class="mono">{{s4g.topic_data||'test/'}}</span> (ou <span class="mono">#</span>). A aba <b>Nuvem</b> deste app também mostra o que o IoT Core recebeu.</p>
       <div class="callout amber" style="margin-top:10px"><b>Atenção à policy do AWS IoT:</b> o certificado só publica/assina em tópicos permitidos pela IoT Policy <span class="mono">Kurc-Building-POC-Policy</span>, que hoje libera apenas <span class="mono">Kurc-Building-*</span>. Por isso o tópico é <span class="mono">{{s4g.topic_data||'Kurc-Building-Central'}}</span>. Um tópico fora desse padrão (ex. <span class="mono">test/</span>) faz a AWS <b>derrubar a conexão</b> logo após o CONNECT (conecta, mas cai ao assinar/publicar).</div>
      </div>
     </div>
    </div>

    <div class="callout"><b>Como o ADW300 conecta (vídeo oficial Acrel):</b> MQTT direto no AWS por TLS mútuo (X.509). Tudo é gravado uma vez pelo software ACREL: Domain 1 = endpoint, MQTT = tópico, SSL/TLS = os 3 .bin. Depois o USB e o PC são removidos.</div>
    <details style="margin-top:8px"><summary>Avançado: ler/gravar registrador Modbus</summary>
     <div class="frm" style="max-width:520px;margin-top:10px">
      <label>Endereço (decimal)</label><input type="number" v-model="raw.addr">
      <label>Qtde (leitura)</label><input type="number" v-model="raw.count">
      <label>Valor (gravar, opcional)</label><input type="number" v-model="raw.write" placeholder="vazio = ler">
     </div>
     <div class="btnrow" style="margin-top:10px"><button class="ghost" @click="rawExec">Executar</button></div>
     <div class="msg" :class="rawMsg.startsWith('ok')?'ok':'bad'" v-if="rawMsg">{{rawMsg.startsWith('ok')?('✓ '+rawMsg.slice(3)):('⚠ '+rawMsg.slice(4))}}</div>
    </details>
   </div>
  </section>

  <!-- NUVEM -->
  <section v-show="view==='nuvem'">
   <div class="page-h"><div><h1>Nuvem / AWS IoT Core</h1><p>O app está conectado ao AWS (Web-Certs) e, ao mesmo tempo que publica, assina o tópico e mostra aqui o que chega — inclusive os dados que o medidor envia pela 4G.</p></div></div>
   <div class="cards">
    <div class="card tile"><div class="lab">Conexão AWS</div><div class="val"><span class="pill" :class="st.aws_connected?'ok':'bad'"><span class="dot"></span>{{st.aws_connected?'CONECTADO':'OFFLINE'}}</span></div><div class="sub">identidade Web-Certs</div></div>
    <div class="card tile"><div class="lab">Assinatura</div><div class="val"><span class="pill" :class="st.subscribing?'ok':'mut'"><span class="dot"></span>{{st.subscribing?'ATIVA':'—'}}</span></div><div class="sub">tópico {{cloud.topic||'—'}}</div></div>
    <div class="card tile"><div class="lab">Mensagens recebidas</div><div class="val">{{cloud.count||0}}</div><div class="sub">{{cloud.last?('últ. '+cloud.last.substr(11,8)+'Z'):'—'}}</div></div>
    <div class="card tile"><div class="lab">Dispositivo</div><div class="val" style="font-size:17px">{{cloud.device||'—'}}</div><div class="sub">payload do medidor</div></div>
    <div class="card tile"><div class="lab">Envio ao AWS {{st.mode==='simulator'?'(simulado)':''}}</div>
     <div class="switchrow" @click="togglePublish"><div class="switch" :class="{on:st.publishing}"><span></span></div><b>{{st.publishing?'ATIVADO':'DESATIVADO'}}</b></div>
     <div class="sub">{{st.publishing?'publicando no tópico':'parado — nada é enviado'}}</div></div>
   </div>
   <div class="grid2 wide">
    <div class="panel"><div class="phead"><h2>Potência total recebida</h2><span class="tag">do AWS · kW</span></div><div class="chart" ref="cline"></div></div>
    <div class="panel"><h2>Mensagens recebidas (log)</h2><pre class="log">{{cloud.log?cloud.log.join('\\n'):''}}</pre></div>
   </div>
   <div class="panel"><h2>Grandezas recebidas do AWS</h2>
    <div class="tbl-wrap"><table><thead><tr><th>ID</th><th>Grandeza</th><th class="r">Valor</th><th>Un.</th></tr></thead>
     <tbody><template v-for="id in ids" :key="id"><tr v-if="cloud.values[id]!==undefined"><td>{{id}}</td><td>{{nm(id)}}</td><td class="v">{{cloud.values[id]}}</td><td class="u">{{un(id)}}</td></tr></template>
     <tr v-if="!cloud.count"><td colspan="4" class="muted">Aguardando mensagens do AWS...</td></tr></tbody></table></div>
   </div>
  </section>

  <!-- SOBRE -->
  <section v-show="view==='sobre'">
   <div class="page-h"><div><h1>Sobre / Arquitetura</h1></div></div>
   <div class="panel"><h2>Para que serve</h2><p>O ADW300 <b>4G</b> (sem Wi-Fi) tem chip celular e envia os dados por MQTT <b>direto</b> ao AWS IoT Core. Este app configura esse envio (pelo USB-RS485) e testa/visualiza o fluxo. Concluído o setup, o USB e o PC são retirados.</p></div>
   <div class="panel"><h2>Caminhos</h2><ul class="bl">
     <li><b>Produção:</b> ADW300 &rarr; 4G &rarr; AWS IoT Core (TLS mútuo, ADW300-Certs).</li>
     <li><b>Este app (setup/teste):</b> lê por RS485, publica e <b>assina</b> no AWS (Web-Certs) em paralelo.</li></ul></div>
   <div class="panel"><h2>Engenharia reversa</h2><ul class="bl">
     <li>Payload = 73 grandezas (ids 0-72) em JSON.</li>
     <li>RS485 = Modbus-RTU 03H; mapa do manual oficial ADW300.</li>
     <li>Config AWS (software ACREL): Domain 1, MQTT, SSL/TLS (3 certificados .bin).</li>
     <li>Referência: vídeo oficial Acrel "ADW300 IoT Energy Meter connect to AWS IoT Platform".</li></ul></div>
  </section>
 </main>
</div>`
}).mount("#app");
