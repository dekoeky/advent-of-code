namespace advent_of_code._2015.Day19;

public static class Inputs
{
    public const string Part1Example =
        """
        H => HO
        H => OH
        O => HH

        HOH
        """;

    public const string Part2Example =
        """
        e => H
        e => O
        H => HO
        H => OH
        O => HH

        e
        """;

    public const string Puzzle =
        """
        Al => ThF
        Al => ThRnFAr
        B => BCa
        B => TiB
        B => TiRnFAr
        Ca => CaCa
        Ca => PB
        Ca => PRnFAr
        Ca => SiRnFYFAr
        Ca => SiRnMgAr
        Ca => SiTh
        F => CaF
        F => PMg
        F => SiAl
        H => CRnAlAr
        H => CRnFYFYFAr
        H => CRnFYMgAr
        H => CRnMgYFAr
        H => HCa
        H => NRnFYFAr
        H => NRnMgAr
        H => NTh
        H => OB
        H => ORnFAr
        Mg => BF
        Mg => TiMg
        N => CRnFAr
        N => HSi
        O => CRnFYFAr
        O => CRnMgAr
        O => HP
        O => NRnFAr
        O => OTi
        P => CaP
        P => PTi
        P => SiRnFAr
        Si => CaSi
        Th => ThCa
        Ti => BP
        Ti => TiTi
        e => HF
        e => NAl
        e => OMg

        CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF
        """;
}
